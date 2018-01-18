�
kE:\Scoala\Anul III\Sem I\i.Net\Project\Microservices\Alarms\Business\Automapper\AlarmsMappings.cs
	namespace 	
Business
 
. 

Automapper 
{ 
public 

class 
AlarmsMappings $
:% &
Profile' .
{ 
public		 
AlarmsMappings		 "
(		" #
)		# $
{

 	
	CreateMap 
< 
AlarmsRecord '
,' (#
GetAlarmsRecordDto) @
>@ A
(A B
)B C
;C D
	CreateMap 
< 
AlarmsRecord '
,' (+
GetAlarmsRecordWithUserDto) H
>H I
(I J
)J K
;K L
	CreateMap 
< #
AddAlarmsRecordDto -
,- .
AlarmsRecord/ @
>@ A
(A B
)B C
;C D
} 	
} 
} �
pE:\Scoala\Anul III\Sem I\i.Net\Project\Microservices\Alarms\Business\Dtos\Atomic\AddAlarmsRecordDto.cs
	namespace 	
Business
 
. 
Dtos 
{ 
public 

class #
AddAlarmsRecordDto (
{ 
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
public		 
double		 
Value		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
public 
DateTime 
Time 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} �
pE:\Scoala\Anul III\Sem I\i.Net\Project\Microservices\Alarms\Business\Dtos\Atomic\GetAlarmsRecordDto.cs
	namespace 	
Business
 
. 
Dtos 
{ 
public 

class #
GetAlarmsRecordDto (
{ 
public 
double 
Value 
{ 
get !
;! "
set# &
;& '
}( )
public		 
DateTime		 
Time		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
}

 
} �
xE:\Scoala\Anul III\Sem I\i.Net\Project\Microservices\Alarms\Business\Dtos\Atomic\GetAlarmsRecordWithUserDto.cs
	namespace 	
Business
 
. 
Dtos 
{ 
public 

class +
GetAlarmsRecordWithUserDto 0
{ 
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
public		 
double		 
Value		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
public 
DateTime 
Time 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} �
mE:\Scoala\Anul III\Sem I\i.Net\Project\Microservices\Alarms\Business\Dtos\GetAllAlarmsRecordsDto.cs
	namespace 	
Business
 
. 
Dtos 
{ 
public 

class '
GetAllAlarmsRecordsDto ,
{ 
public 
List 
< +
GetAlarmsRecordWithUserDto 3
>3 4
AlarmsRecords5 G
;G H
public		 '
GetAllAlarmsRecordsDto		 *
(		* +
List		+ /
<		/ 0+
GetAlarmsRecordWithUserDto		0 O
>		O P
alarmsRecords		Q c
)		c d
{

 	
AlarmsRecords 
=  
alarmsRecords! 3
;3 4
} 	
} 
} �
nE:\Scoala\Anul III\Sem I\i.Net\Project\Microservices\Alarms\Business\Dtos\GetUserAlarmsRecordsDto.cs
	namespace 	
Business
 
. 
Dtos 
{ 
public 

class (
GetUserAlarmsRecordsDto -
{ 
public 
List 
< #
GetAlarmsRecordDto +
>+ ,
AlarmsRecords- ?
;? @
public		 (
GetUserAlarmsRecordsDto		 +
(		+ ,
List		, 0
<		0 1#
GetAlarmsRecordDto		1 H
>		H I
alarmsRecords		J \
)		\ ]
{

 	
AlarmsRecords 
=  
alarmsRecords! 3
;3 4
} 	
} 
} �
jE:\Scoala\Anul III\Sem I\i.Net\Project\Microservices\Alarms\Business\Services\AddAlarmsRecord.cs
	namespace 	
Business
 
. 
Services 
{ 
public 

partial 
class 
AlarmsService +
{ 
public		 
Guid		  
AddAlarmsRecord		 (
(		( )#
AddAlarmsRecordDto		) @
record		A G
)		G H
{

 	
var 
toStore 
= 
_mapper !
.! "
Map" %
<% &
AlarmsRecord& 7
>7 8
(8 9
record9 ?
)? @
;@ A
_repo 
. 
Add 
( 
toStore 
) 
; 
_repo 
. 
SaveChanges 
( 
) 
;  
return 
toStore 
. 
Id 
; 
} 	
} 
} �	
nE:\Scoala\Anul III\Sem I\i.Net\Project\Microservices\Alarms\Business\Services\GetAllAlarmsRecords.cs
	namespace 	
Business
 
. 
Services 
{ 
public 

partial 
class 
AlarmsService +
{ 
public		 '
GetAllAlarmsRecordsDto		 *$
GetAllAlarmsRecords		+ C
(		C D
)		D E
{

 	
var 
findings 
= 
_repo  
.  !
GetAll! '
(' (
)( )
;) *
var 
results 
= 
_mapper !
.! "
Map" %
<% &
List& *
<* +
AlarmsRecord+ <
>< =
,= >
List? C
<C D+
GetAlarmsRecordWithUserDtoD c
>c d
>d e
(e f
findingsf n
)n o
;o p
return 
new '
GetAllAlarmsRecordsDto 2
(2 3
results3 :
): ;
;; <
} 	
} 
} �	
oE:\Scoala\Anul III\Sem I\i.Net\Project\Microservices\Alarms\Business\Services\GetUserAlarmsRecords.cs
	namespace 	
Business
 
. 
Services 
{ 
public 

partial 
class 
AlarmsService +
{		 
public

 (
GetUserAlarmsRecordsDto

 +%
GetUserAlarmsRecords

, E
(

E F
Guid

F J
id

K M
)

M N
{ 	
var 
findings 
= 
_repo  
.  !
GetByUserId! ,
(, -
id- /
)/ 0
;0 1
var 
results 
= 
_mapper !
.! "
Map" %
<% &
List& *
<* +
AlarmsRecord+ <
>< =
,= >
List? C
<C D#
GetAlarmsRecordDtoD [
>[ \
>\ ]
(] ^
findings^ f
)f g
;g h
return 
new (
GetUserAlarmsRecordsDto 3
(3 4
results4 ;
); <
;< =
} 	
} 
} �
iE:\Scoala\Anul III\Sem I\i.Net\Project\Microservices\Alarms\Business\Services\IAlarmsService.cs
	namespace 	
Business
 
. 
Services 
{ 
public 

	interface 
IAlarmsService (
{ '
GetAllAlarmsRecordsDto #$
GetAllAlarmsRecords$ <
(< =
)= >
;> ?(
GetUserAlarmsRecordsDto

 $%
GetUserAlarmsRecords

% >
(

> ?
Guid

? C
id

D F
)

F G
;

G H
Guid  
AddAlarmsRecord !
(! "#
AddAlarmsRecordDto" 9
record: @
)@ A
;A B
} 
} �
hE:\Scoala\Anul III\Sem I\i.Net\Project\Microservices\Alarms\Business\Services\AlarmsService.cs
	namespace 	
Business
 
. 
Services 
{ 
public 

partial 
class 
AlarmsService +
:, -
IAlarmsService. A
{ 
private 
readonly "
IAlarmsRepository /
_repo0 5
;5 6
private		 
readonly		 
IMapper		  
_mapper		! (
;		( )
public 
AlarmsService !
(! ""
IAlarmsRepository" 8
repo9 =
,= >
IMapper? F
mapperG M
)M N
{ 	
_repo 
= 
repo 
; 
_mapper 
= 
mapper 
; 
} 	
} 
} 