docker run --name mypostgres -d --rm -p 5432:5432 --network mybridgenetwork -v mypostgresvolume:/var/lib/postgresql/data mypostgres:1

docker run --name mywebapi -d --rm -p 7000:8080 --network mybridgenetwork mywebapi:1