�
gE:\Scoala\Anul III\Sem I\i.Net\Project\Microservices\Alarms\Repositories\IAlarmsRepository.cs
	namespace 	
Repositories
 
{ 
public 

	interface "
IAlarmsRepository +
{ 
List		 
<		 
AlarmsRecord		 
>		 
GetAll		  &
(		& '
)		' (
;		( )
List 
< 
AlarmsRecord 
> 
GetByUserId  +
(+ ,
Guid, 0
userId1 7
)7 8
;8 9
void 
Add 
( 
AlarmsRecord "
record# )
)) *
;* +
void 
SaveChanges 
( 
) 
; 
} 
} �
fE:\Scoala\Anul III\Sem I\i.Net\Project\Microservices\Alarms\Repositories\AlarmsRepository.cs
	namespace 	
Repositories
 
{		 
public

 

class

 !
AlarmsRepository

 &
:

' ("
IAlarmsRepository

) ?
{ 
private 
readonly 
IDatabaseContext )
_context* 2
;2 3
public !
AlarmsRepository $
($ %
IDatabaseContext% 5
context6 =
)= >
{ 	
_context 
= 
context 
; 
} 	
public 
List 
< 
AlarmsRecord %
>% &
GetAll' -
(- .
). /
{ 	
return 
_context 
. 
AlarmsRecords .
.. /
AsNoTracking/ ;
(; <
)< =
.= >
ToList> D
(D E
)E F
;F G
} 	
public 
List 
< 
AlarmsRecord %
>% &
GetByUserId' 2
(2 3
Guid3 7
userId8 >
)> ?
{ 	
return 
_context 
. 
AlarmsRecords .
.. /
Where/ 4
(4 5
x5 6
=>7 9
x: ;
.; <
UserId< B
==C E
userIdF L
)L M
.M N
AsNoTrackingN Z
(Z [
)[ \
.\ ]
ToList] c
(c d
)d e
;e f
} 	
public 
void 
Add 
( 
AlarmsRecord )
record* 0
)0 1
{ 	
_context 
. 
AlarmsRecords '
.' (
Add( +
(+ ,
record, 2
)2 3
;3 4
}   	
public"" 
void"" 
SaveChanges"" 
(""  
)""  !
{## 	
_context$$ 
.$$ 
SaveChanges$$  
($$  !
)$$! "
;$$" #
}%% 	
}&& 
}'' 