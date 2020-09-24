#!/bin/bash

## Remove postgres container
docker stop postgres
docker rm postgres

## Remove postgres image
docker image prune -f

## Remove docker volume
docker volume rm postgres