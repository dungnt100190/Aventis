#!/usr/bin/env bash

IP=`docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' kiss4-db-test`
echo "##vso[task.setvariable variable=DbHost;]$IP"
