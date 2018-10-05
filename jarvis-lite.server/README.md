JarvisLite - Server
----

Back end for JarvisLite. API built in .NET CORE (ASP.NET MVC).


Requirements
----

In order to run this container you'll need docker installed.


Usage
----

1. Navigate to the project folder.
2. Use the following commands to build and run the docker image:

**Build**
```bash
$ docker build -t jarvis-lite.server .
```

**Run**
```bash
$ docker run -d -p 5000:80 --name server jarvis-lite.server
```

Server is now up and running at localhost:5000!


Additional notes
----

Data for homes and rooms was hard-coded whilst room values are generated dynamically in /Utilities/GenerateData/GenerateData.cs.

This (I hope) should do the trick for demonstration purposes. In terms of scalability, though, it would be better to implement a proper db and not hard-code the data. Yet given the scope of the assignment I thought that this would be overkill...



