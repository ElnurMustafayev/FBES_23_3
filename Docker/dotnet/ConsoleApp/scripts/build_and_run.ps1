docker build -t consoleapp_image:2.0 .
docker run -d --name consoleapp_container --rm consoleapp_image:2.0