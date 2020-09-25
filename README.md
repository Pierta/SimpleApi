# SimpleApi
Simple rest api boilerplate

**Tested:**
- Windows 10 PRO

**Prerequisites:**
- docker desktop

**Debug run instructions:**
```
cd LocalPostgresScripts
./SetupLocalPostgres12InDocker.sh
cd ..
dotnet run -p SimpleApi/
# REST API WILL BE AWAILABLE ON http://localhost:5000

# After testing:
# ctrl + C
./RemoveLocalPostgres12.sh
```

**Release run instructions:**
```
docker-compose up -d
# REST API WILL BE AWAILABLE ON http://localhost

# After testing
docker-compose down
docker image prune -f
docker image rmi simpleapi_prometheus
docker image rmi simpleapi_simpleapi
docker volume rm simpleapi_postgres
```