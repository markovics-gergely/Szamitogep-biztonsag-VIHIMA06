dotnet sonarscanner begin /k:"Webshop" /d:sonar.host.url="http://localhost:9000"  /d:sonar.login="sqp_b104cae13a62b2341b1cf4cc56cc43371606bd3d"
dotnet build
dotnet sonarscanner end /d:sonar.login="sqp_b104cae13a62b2341b1cf4cc56cc43371606bd3d"