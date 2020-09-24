#!/bin/bash

## Update Postgres database (update existed database to actual state)
dotnet ef database update -v -p ../../SimpleApi.Domain.DB -s ../../SimpleApi