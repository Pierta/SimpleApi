#!/bin/bash

docker run -it --rm --net simple-network -e PGPASSWORD=simple-password! postgres:12 psql -h postgres -U simple-user simple-db