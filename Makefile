build:
	dotnet build -c Release
	dotnet publish -c Release -o ./publish

container: container-stop build
	docker build -t election-api:local .
	docker save election-api > /tmp/election-api.tar
	microk8s ctr image import /tmp/election-api.tar
	microk8s.kubectl apply -f election-api-deployment.yaml
	microk8s.kubectl apply -f election-api-service.yaml
	microk8s.kubectl apply -f election-api-ingress.yaml


container-stop:
	microk8s.kubectl delete deployment election-api-deployment || true
	microk8s.kubectl delete service election-api-svc || true
	microk8s.kubectl delete ingress election-api-ingress || true
	microk8s ctr images rm docker.io/library/election-api:local || true
	docker rmi docker.io/library/election-api:local --force || true
	rm /tmp/election-api.tar || true


test:
	curl https://infinitytek.xyz/election/hello

logs:
	docker logs election-api
