build:
	dotnet build -c Release
	dotnet publish -c Release -o ./publish

clean:
	docker stop election-api || true
	docker rm election-api || true

container: clean build
	docker build -t election-api:local .
	docker run -d -p 3333:8080 \
      -e ASPNETCORE_URLS=http://+:8080 \
      --name election-api \
      election-api:local


test:
	docker exec -it election-api curl http://localhost:8080/hello
	curl -v http://localhost:3333/hello

logs:
	docker logs election-api
