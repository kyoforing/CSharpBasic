Hi Trainees

Greeting, in order to provide more efficient training class, 
I want you do some pre-work 
Please go to https://github.com/kyoangel/CSharpBasic Clone project,
Write a simple api and send pull request to me.
(you also can create project by yourself, and zip to me)

Basic requirement:
implement an API that get your IP and CountryCode with specific url
http://localhost:5487/api/WhereAmI

Plus feature,
1.	Log something you need
2.	Could auto retry x times if error or timeout
3.	Limited x access times within x minute
4.	Other API Good design (do as much as you can)

-----------------------------------------------------------------------------
Implement hint:
you can try to call
https://api.ipify.org?format=json
with get method, to get your ip
then call
http://ip-api.com/batch
with post method,
data
[
  "your IP"
]
To get details
-----------------------------------------------------------------------------