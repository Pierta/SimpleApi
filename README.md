# SimpleApi
Simple rest api boilerplate

**Tested:**
- Windows 10 PRO

**Prerequisites:**
- docker desktop

**Windows 10 run instructions:**
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

**Linux run instructions:**
```
docker-compose up
# REST API WILL BE AWAILABLE ON http://localhost

# After testing
# ctrl + C
docker-compose down
```