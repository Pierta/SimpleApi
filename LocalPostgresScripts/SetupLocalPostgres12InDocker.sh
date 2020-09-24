#!/bin/bash

## Create docker volume
docker volume create postgres

## Run postgresql 12 in docker
docker run -d --name postgres --restart=unless-stopped -p 5432:5432 \
	-e POSTGRES_DB=simple-db -e POSTGRES_USER=simple-user -e POSTGRES_PASSWORD=simple-password! \
	-v postgres:/var/lib/postgresql/data postgres:12 \
	-c 'shared_buffers=512MB'