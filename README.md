Hi Trainees

Greeting, in order to provide more efficient training class, I want you do some pre-work Please go to https://github.com/kyoangel/CSharpBasic Clone project, Write a simple api and send pull request to me. (you also can create project by yourself, and zip to me)

Basic requirement: 
implement an API that get your IP and CountryCode with specific url http://localhost:80/api/WhereAmI

SKA feature: 
Log something you need.
Could auto retry x times if error or timeout.
Applided some limits. for example: Limited x access times within x minute, limit specific ip access. 
Dependency Injection applied. (httpclient, actionfilter)
Action filter applied. (logger or limits)
swagger api doc

Implement hint: 
you can try to call https://api.ipify.org?format=json with get method, to get your ip (or use ip in request)
then call http://ip-api.com/batch with post method, data [ "your IP" ] To get details
