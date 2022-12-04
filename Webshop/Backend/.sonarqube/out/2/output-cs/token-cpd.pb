∏Y
wE:\Desktop\Szamitogep_biztonsag\Szamitogep-biztonsag-VIHIMA06\Webshop\Backend\Webshop.API\Controllers\CaffController.cs
	namespace 	
Webshop
 
. 
API 
. 
Controllers !
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
[ 
ApiConventionType 
( 
typeof 
( !
DefaultApiConventions 3
)3 4
)4 5
]5 6
[ 
	Authorize 
( 
Roles 
= 
	RoleTypes  
.  !
All! $
)$ %
]% &
public 

class 
CaffController 
:  !
ControllerBase" 0
{ 
private 
readonly 
	IMediator "
	_mediator# ,
;, -
private 
readonly (
IWebshopConfigurationService 5
_config6 =
;= >
public 
CaffController 
( 
	IMediator '
mediator( 0
,0 1(
IWebshopConfigurationService2 N
configO U
)U V
{ 	
	_mediator 
= 
mediator  
;  !
_config 
= 
config 
; 
} 	
[   	
HttpGet  	 
]   
public!! 
async!! 
Task!! 
<!! 
ActionResult!! &
<!!& '(
EnumerableWithTotalViewModel!!' C
<!!C D
CaffListViewModel!!D U
>!!U V
>!!V W
>!!W X
GetCaffList!!Y d
(!!d e
["" 
	FromQuery"" 
]"" 
GetCaffsDto"" #
dto""$ '
,""' (
CancellationToken## 
cancellationToken## /
)##/ 0
{$$ 	
var%% 
query%% 
=%% 
new%% 
GetCaffListQuery%% ,
(%%, -
dto%%- 0
,%%0 1
User%%2 6
)%%6 7
;%%7 8
return&& 
Ok&& 
(&& 
await&& 
	_mediator&& %
.&&% &
Send&&& *
(&&* +
query&&+ 0
,&&0 1
cancellationToken&&2 C
)&&C D
)&&D E
;&&E F
}'' 	
[)) 	
HttpGet))	 
()) 
$str)) 
))) 
])) 
public** 
async** 
Task** 
<** 
ActionResult** &
<**& '
CaffListViewModel**' 8
>**8 9
>**9 :
GetCaffDetails**; I
(**I J
[++ 
	FromRoute++ 
]++ 
Guid++ 
caffId++ #
,++# $
CancellationToken,, 
cancellationToken,, /
),,/ 0
{-- 	
var.. 
query.. 
=.. 
new.. 
GetCaffDetailsQuery.. /
(../ 0
caffId..0 6
,..6 7
User..8 <
)..< =
;..= >
return// 
Ok// 
(// 
await// 
	_mediator// %
.//% &
Send//& *
(//* +
query//+ 0
,//0 1
cancellationToken//2 C
)//C D
)//D E
;//E F
}00 	
[22 	
HttpPost22	 
(22 
$str22 )
)22) *
]22* +
public33 
async33 
Task33 
<33 
IActionResult33 '
>33' (
PostComment33) 4
(334 5
[44 
	FromRoute44 
]44 
Guid44 
caffId44 #
,44# $
[55 
FromForm55 
]55 
PostCommentDto55 %
dto55& )
,55) *
CancellationToken66 
cancellationToken66 /
)66/ 0
{77 	
var88 
command88 
=88 
new88 
PostCommentCommand88 0
(880 1
caffId881 7
,887 8
User889 =
,88= >
dto88? B
)88B C
;88C D
return99 
Ok99 
(99 
await99 
	_mediator99 %
.99% &
Send99& *
(99* +
command99+ 2
,992 3
cancellationToken994 E
)99E F
)99F G
;99G H
}:: 	
[<< 	

HttpDelete<<	 
(<< 
$str<< .
)<<. /
]<</ 0
public== 
async== 
Task== 
<== 
IActionResult== '
>==' (
DeleteComment==) 6
(==6 7
[>> 
	FromRoute>> 
]>> 
Guid>> 
caffId>> #
,>># $
[?? 
FromBody?? 
]?? 
RemoveCommentDto?? '
dto??( +
,??+ ,
CancellationToken@@ 
cancellationToken@@ /
)@@/ 0
{AA 	
varBB 
commandBB 
=BB 
newBB  
RemoveCommentCommandBB 2
(BB2 3
caffIdBB3 9
,BB9 :
UserBB; ?
,BB? @
dtoBBA D
)BBD E
;BBE F
returnCC 
OkCC 
(CC 
awaitCC 
	_mediatorCC %
.CC% &
SendCC& *
(CC* +
commandCC+ 2
,CC2 3
cancellationTokenCC4 E
)CCE F
)CCF G
;CCG H
}DD 	
[FF 	
HttpPostFF	 
]FF 
publicGG 
asyncGG 
TaskGG 
<GG 
ActionResultGG &
<GG& '
GuidGG' +
>GG+ ,
>GG, -

UploadCaffGG. 8
(GG8 9
[GG9 :
FromFormGG: B
]GGB C
UploadCaffDtoGGD Q
dtoGGR U
,GGU V
CancellationTokenGGW h
cancellationTokenGGi z
)GGz {
{HH 	
varII 
commandII 
=II 
newII 
UploadCaffCommandII /
(II/ 0
dtoII0 3
,II3 4
HttpContextII5 @
.II@ A
UserIIA E
)IIE F
;IIF G
returnJJ 
OkJJ 
(JJ 
awaitJJ 
	_mediatorJJ %
.JJ% &
SendJJ& *
(JJ* +
commandJJ+ 2
,JJ2 3
cancellationTokenJJ4 E
)JJE F
)JJF G
;JJG H
}KK 	
[MM 	

HttpDeleteMM	 
(MM 
$strMM 
)MM 
]MM  
publicNN 
asyncNN 
TaskNN 
<NN 
IActionResultNN '
>NN' (

DeleteCaffNN) 3
(NN3 4
[NN4 5
	FromRouteNN5 >
]NN> ?
GuidNN@ D
caffIdNNE K
,NNK L
CancellationTokenNNM ^
cancellationTokenNN_ p
)NNp q
{OO 	
varPP 
commandPP 
=PP 
newPP 
DeleteCaffCommandPP /
(PP/ 0
caffIdPP0 6
,PP6 7
HttpContextPP8 C
.PPC D
UserPPD H
)PPH I
;PPI J
returnQQ 
OkQQ 
(QQ 
awaitQQ 
	_mediatorQQ %
.QQ% &
SendQQ& *
(QQ* +
commandQQ+ 2
,QQ2 3
cancellationTokenQQ4 E
)QQE F
)QQF G
;QQG H
}RR 	
[TT 	
HttpPostTT	 
(TT 
$strTT %
)TT% &
]TT& '
publicUU 
asyncUU 
TaskUU 
<UU 
IActionResultUU '
>UU' (
BuyCaffUU) 0
(UU0 1
[UU1 2
	FromRouteUU2 ;
]UU; <
GuidUU= A
caffIdUUB H
,UUH I
CancellationTokenUUJ [
cancellationTokenUU\ m
)UUm n
{VV 	
varWW 
commandWW 
=WW 
newWW 
BuyCaffCommandWW ,
(WW, -
caffIdWW- 3
,WW3 4
HttpContextWW5 @
.WW@ A
UserWWA E
)WWE F
;WWF G
returnXX 
OkXX 
(XX 
awaitXX 
	_mediatorXX %
.XX% &
SendXX& *
(XX* +
commandXX+ 2
,XX2 3
cancellationTokenXX4 E
)XXE F
)XXF G
;XXG H
}YY 	
[[[ 	
HttpGet[[	 
([[ 
$str[[ $
)[[$ %
][[% &
public\\ 
async\\ 
Task\\ 
<\\ 
IActionResult\\ '
>\\' (
DownloadCaff\\) 5
(\\5 6
[\\6 7
	FromRoute\\7 @
]\\@ A
Guid\\B F
caffId\\G M
,\\M N
CancellationToken\\O `
cancellationToken\\a r
)\\r s
{]] 	
var^^ 
command^^ 
=^^ 
new^^  
GetCaffDownloadQuery^^ 2
(^^2 3
caffId^^3 9
,^^9 :
HttpContext^^; F
.^^F G
User^^G K
)^^K L
;^^L M
return__ 
File__ 
(__ 
await__ 
	_mediator__ '
.__' (
Send__( ,
(__, -
command__- 4
,__4 5
cancellationToken__6 G
)__G H
,__H I
$str__J d
,__d e
fileDownloadName__f v
:__v w
$"__x z
{__z {
DateTime	__{ É
.
__É Ñ
Now
__Ñ á
}
__á à
$str
__à ç
"
__ç é
)
__é è
;
__è ê
}`` 	
[bb 	
HttpPutbb	 
(bb 
$strbb 
)bb 
]bb 
publiccc 
asynccc 
Taskcc 
<cc 
IActionResultcc '
>cc' (
EditCaffDatacc) 5
(cc5 6
[cc6 7
	FromRoutecc7 @
]cc@ A
GuidccB F
caffIdccG M
,ccM N
[ccO P
FromBodyccP X
]ccX Y
EditCaffDtoccZ e
dtoccf i
,cci j
CancellationTokencck |
cancellationToken	cc} é
)
ccé è
{dd 	
varee 
commandee 
=ee 
newee 
EditCaffDataCommandee 1
(ee1 2
caffIdee2 8
,ee8 9
dtoee: =
,ee= >
HttpContextee? J
.eeJ K
UsereeK O
)eeO P
;eeP Q
returnff 
Okff 
(ff 
awaitff 
	_mediatorff %
.ff% &
Sendff& *
(ff* +
commandff+ 2
,ff2 3
cancellationTokenff4 E
)ffE F
)ffF G
;ffG H
}gg 	
[ii 	
HttpGetii	 
(ii 
$strii 
)ii 
]ii 
publicjj 
IActionResultjj 
	GetConfigjj &
(jj& '
)jj' (
{kk 	
returnll 
Okll 
(ll 
newll 
{ll 
MaxUploadSizell )
=ll* +
_configll, 3
.ll3 4
GetMaxUploadSizell4 D
(llD E
)llE F
,llF G
MaxUploadCountllH V
=llW X
_configllY `
.ll` a
GetMaxUploadCountlla r
(llr s
)lls t
}llu v
)llv w
;llw x
}mm 	
}nn 
}oo ˚L
wE:\Desktop\Szamitogep_biztonsag\Szamitogep-biztonsag-VIHIMA06\Webshop\Backend\Webshop.API\Controllers\UserController.cs
	namespace 	
Webshop
 
. 
API 
. 
Controllers !
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
[ 
ApiConventionType 
( 
typeof 
( !
DefaultApiConventions 3
)3 4
)4 5
]5 6
[ 
	Authorize 
( 
Roles 
= 
	RoleTypes  
.  !
All! $
)$ %
]% &
public 

class 
UserController 
:  !
ControllerBase" 0
{ 
private 
readonly 
	IMediator "
	_mediator# ,
;, -
public 
UserController 
( 
	IMediator '
mediator( 0
)0 1
{ 	
	_mediator 
= 
mediator  
;  !
}   	
[(( 	
HttpGet((	 
((( 
$str(( "
)((" #
]((# $
public)) 
async)) 
Task)) 
<)) 
ActionResult)) &
<))& '$
ProfileWithNameViewModel))' ?
>))? @
>))@ A
GetUserByIdAsync))B R
())R S
string))S Y
userid))Z `
,))` a
CancellationToken))b s
cancellationToken	))t Ö
)
))Ö Ü
{** 	
var++ 
query++ 
=++ 
new++ 
GetUserQuery++ (
(++( )
userid++) /
)++/ 0
;++0 1
return,, 
Ok,, 
(,, 
await,, 
	_mediator,, %
.,,% &
Send,,& *
(,,* +
query,,+ 0
,,,0 1
cancellationToken,,2 C
),,C D
),,D E
;,,E F
}-- 	
[44 	
HttpGet44	 
(44 
$str44 
)44 
]44 
public55 
async55 
Task55 
<55 
ActionResult55 &
<55& '
ProfileViewModel55' 7
>557 8
>558 9
GetProfileAsync55: I
(55I J
CancellationToken55J [
cancellationToken55\ m
)55m n
{66 	
var77 
query77 
=77 
new77 
GetProfileQuery77 +
(77+ ,
)77, -
;77- .
return88 
Ok88 
(88 
await88 
	_mediator88 %
.88% &
Send88& *
(88* +
query88+ 0
,880 1
cancellationToken882 C
)88C D
)88D E
;88E F
}99 	
[@@ 	
HttpGet@@	 
(@@ 
$str@@ 
)@@  
]@@  !
publicAA 
asyncAA 
TaskAA 
<AA 
ActionResultAA &
<AA& '$
ProfileWithNameViewModelAA' ?
>AA? @
>AA@ A
GetFullProfileAsyncAAB U
(AAU V
CancellationTokenAAV g
cancellationTokenAAh y
)AAy z
{BB 	
varCC 
queryCC 
=CC 
newCC 
GetFullProfileQueryCC /
(CC/ 0
)CC0 1
;CC1 2
returnDD 
OkDD 
(DD 
awaitDD 
	_mediatorDD %
.DD% &
SendDD& *
(DD* +
queryDD+ 0
,DD0 1
cancellationTokenDD2 C
)DDC D
)DDD E
;DDE F
}EE 	
[LL 	
HttpGetLL	 
(LL 
$strLL 
)LL 
]LL 
publicMM 
asyncMM 
TaskMM 
<MM 
ActionResultMM &
<MM& '
stringMM' -
>MM- .
>MM. /"
GetAccountsByUserAsyncMM0 F
(MMF G
CancellationTokenMMG X
cancellationTokenMMY j
)MMj k
{NN 	
varOO 
queryOO 
=OO 
newOO  
GetActualUserIdQueryOO 0
(OO0 1
)OO1 2
;OO2 3
returnPP 
OkPP 
(PP 
awaitPP 
	_mediatorPP %
.PP% &
SendPP& *
(PP* +
queryPP+ 0
,PP0 1
cancellationTokenPP2 C
)PPC D
)PPD E
;PPE F
}QQ 	
[YY 	
	AuthorizeYY	 
(YY 
RolesYY 
=YY 
	RoleTypesYY $
.YY$ %
AdminYY% *
)YY* +
]YY+ ,
[ZZ 	
HttpGetZZ	 
(ZZ 
$strZZ 
)ZZ 
]ZZ  
public[[ 
async[[ 
Task[[ 
<[[ 
ActionResult[[ &
<[[& '
IEnumerable[[' 2
<[[2 3
UserNameViewModel[[3 D
>[[D E
>[[E F
>[[F G
GetUsersByRoleAsync[[H [
([[[ \
string[[\ b
role[[c g
,[[g h
CancellationToken[[i z
cancellationToken	[[{ å
)
[[å ç
{\\ 	
var]] 
query]] 
=]] 
new]] 
GetUsersByRoleQuery]] /
(]]/ 0
role]]0 4
)]]4 5
;]]5 6
return^^ 
Ok^^ 
(^^ 
await^^ 
	_mediator^^ %
.^^% &
Send^^& *
(^^* +
query^^+ 0
,^^0 1
cancellationToken^^2 C
)^^C D
)^^D E
;^^E F
}__ 	
[gg 	
HttpPutgg	 
(gg 
$strgg 
)gg 
]gg 
publichh 
asynchh 
Taskhh 
<hh 
ActionResulthh &
<hh& '
boolhh' +
>hh+ ,
>hh, -
EditUserAsynchh. ;
(hh; <
[hh< =
FromBodyhh= E
]hhE F
EditUserDtohhG R
userDTOhhS Z
,hhZ [
CancellationTokenhh\ m
cancellationTokenhhn 
)	hh Ä
{ii 	
varjj 
commandjj 
=jj 
newjj 
EditUserCommandjj -
(jj- .
userDTOjj. 5
)jj5 6
;jj6 7
returnkk 
awaitkk 
	_mediatorkk "
.kk" #
Sendkk# '
(kk' (
commandkk( /
,kk/ 0
cancellationTokenkk1 B
)kkB C
;kkC D
}ll 	
[tt 	
AllowAnonymoustt	 
]tt 
[uu 	
HttpPostuu	 
(uu 
$struu  
)uu  !
]uu! "
publicvv 
asyncvv 
Taskvv 
<vv 
ActionResultvv &
<vv& '
boolvv' +
>vv+ ,
>vv, -
RegisterUserAsyncvv. ?
(vv? @
[vv@ A
FromBodyvvA I
]vvI J
RegisterUserDtovvK Z
userDTOvv[ b
,vvb c
CancellationTokenvvd u
cancellationToken	vvv á
)
vvá à
{ww 	
varxx 
commandxx 
=xx 
newxx 
CreateUserCommandxx /
(xx/ 0
userDTOxx0 7
)xx7 8
;xx8 9
returnyy 
awaityy 
	_mediatoryy "
.yy" #
Sendyy# '
(yy' (
commandyy( /
,yy/ 0
cancellationTokenyy1 B
)yyB C
;yyC D
}zz 	
[
ÇÇ 	
	Authorize
ÇÇ	 
(
ÇÇ 
Roles
ÇÇ 
=
ÇÇ 
	RoleTypes
ÇÇ $
.
ÇÇ$ %
Admin
ÇÇ% *
)
ÇÇ* +
]
ÇÇ+ ,
[
ÉÉ 	
HttpPost
ÉÉ	 
(
ÉÉ 
$str
ÉÉ 
)
ÉÉ  
]
ÉÉ  !
public
ÑÑ 
async
ÑÑ 
Task
ÑÑ 
<
ÑÑ 
ActionResult
ÑÑ &
>
ÑÑ& ' 
EditUserRolesAsync
ÑÑ( :
(
ÑÑ: ;
[
ÑÑ; <
FromBody
ÑÑ< D
]
ÑÑD E
EditUserRoleDto
ÑÑF U
userRoleDTO
ÑÑV a
,
ÑÑa b
CancellationToken
ÑÑc t 
cancellationTokenÑÑu Ü
)ÑÑÜ á
{
ÖÖ 	
var
ÜÜ 
command
ÜÜ 
=
ÜÜ 
new
ÜÜ !
EditUserRoleCommand
ÜÜ 1
(
ÜÜ1 2
userRoleDTO
ÜÜ2 =
)
ÜÜ= >
;
ÜÜ> ?
await
áá 
	_mediator
áá 
.
áá 
Send
áá  
(
áá  !
command
áá! (
,
áá( )
cancellationToken
áá* ;
)
áá; <
;
áá< =
return
àà 
Ok
àà 
(
àà 
)
àà 
;
àà 
}
ââ 	
[
ãã 	
HttpGet
ãã	 
(
ãã 
$str
ãã 
)
ãã 
]
ãã 
public
åå 
async
åå 
Task
åå 
<
åå 
IActionResult
åå '
>
åå' (
GetUserInventory
åå) 9
(
åå9 :
[
åå: ;
	FromQuery
åå; D
]
ååD E
GetCaffsDto
ååF Q
caffsDTO
ååR Z
,
ååZ [
CancellationToken
åå\ m
cancellationToken
åån 
)åå Ä
{
çç 	
var
éé 
query
éé 
=
éé 
new
éé !
GetBoughtCaffsQuery
éé /
(
éé/ 0
caffsDTO
éé0 8
,
éé8 9
User
éé: >
)
éé> ?
;
éé? @
return
èè 
Ok
èè 
(
èè 
await
èè 
	_mediator
èè %
.
èè% &
Send
èè& *
(
èè* +
query
èè+ 0
,
èè0 1
cancellationToken
èè2 C
)
èèC D
)
èèD E
;
èèE F
}
êê 	
}
ëë 
}íí ø
E:\Desktop\Szamitogep_biztonsag\Szamitogep-biztonsag-VIHIMA06\Webshop\Backend\Webshop.API\Extensions\AuthenticationExtension.cs
	namespace 	
Webshop
 
. 
API 
. 

Extensions  
{ 
public		 

static		 
class		 #
AuthenticationExtension		 /
{

 
public 
static 
void '
AddAuthenticationExtensions 6
(6 7
this7 ;
IServiceCollection< N
servicesO W
,W X
IConfigurationY g
configurationh u
)u v
{ 	#
JwtSecurityTokenHandler #
.# $&
DefaultInboundClaimTypeMap$ >
.> ?
Clear? D
(D E
)E F
;F G
services 
. 
AddAuthentication &
(& '
options' .
=>/ 1
{ 
options 
. 
DefaultScheme %
=& '
JwtBearerDefaults( 9
.9 : 
AuthenticationScheme: N
;N O
options 
. %
DefaultAuthenticateScheme 1
=2 3
JwtBearerDefaults4 E
.E F 
AuthenticationSchemeF Z
;Z [
options 
. "
DefaultChallengeScheme .
=/ 0
JwtBearerDefaults1 B
.B C 
AuthenticationSchemeC W
;W X
} 
) 
. 
AddJwtBearer 
( 
options %
=>& (
{ 
options 
. 
	Authority %
=& '
configuration( 5
.5 6
GetValue6 >
<> ?
string? E
>E F
(F G
$strG a
)a b
;b c
options 
. 
Audience $
=% &
configuration' 4
.4 5
GetValue5 =
<= >
string> D
>D E
(E F
$strF `
)` a
+b c
$strd p
;p q
options 
.  
RequireHttpsMetadata 0
=1 2
false3 8
;8 9
options 
. %
TokenValidationParameters 5
.5 6

ValidTypes6 @
=A B
newC F
[F G
]G H
{I J
$strK S
}T U
;U V
options   
.   %
TokenValidationParameters   5
.  5 6
RoleClaimType  6 C
=  D E
$str  F L
;  L M
options!! 
.!! %
TokenValidationParameters!! 5
.!!5 6
NameClaimType!!6 C
=!!D E
$str!!F L
;!!L M
}"" 
)"" 
;"" 
services$$ 
.$$ 
AddCors$$ 
($$ 
options$$ $
=>$$% '
{%% 
options&& 
.&& 
	AddPolicy&& !
(&&! "
$str&&" .
,&&. /
builder&&0 7
=>&&8 :
{'' 
builder(( 
.(( 
WithOrigins(( '
(((' (
configuration((( 5
.((5 6

GetSection((6 @
(((@ A
$str((A Q
)((Q R
.((R S
Get((S V
<((V W
string((W ]
[((] ^
]((^ _
>((_ `
(((` a
)((a b
)((b c
.)) 
AllowAnyMethod)) *
())* +
)))+ ,
.** 
AllowAnyHeader** *
(*** +
)**+ ,
.++ 
AllowCredentials++ ,
(++, -
)++- .
;++. /
},, 
),, 
;,, 
}-- 
)-- 
;-- 
}.. 	
}// 
}00 —
{E:\Desktop\Szamitogep_biztonsag\Szamitogep-biztonsag-VIHIMA06\Webshop\Backend\Webshop.API\Extensions\AutoMapperExtension.cs
	namespace 	
Webshop
 
. 
API 
. 

Extensions  
{ 
public 

static 
class 
AutoMapperExtension +
{		 
public 
static 
void #
AddAutoMapperExtensions 2
(2 3
this3 7
IServiceCollection8 J
servicesK S
)S T
{ 	
services 
. 
AddAutoMapper "
(" #
typeof# )
() *
UserProfile* 5
)5 6
,6 7
typeof8 >
(> ?
CaffProfile? J
)J K
,K L
typeofM S
(S T
ListProfileT _
)_ `
)` a
;a b
} 	
} 
} à
uE:\Desktop\Szamitogep_biztonsag\Szamitogep-biztonsag-VIHIMA06\Webshop\Backend\Webshop.API\Extensions\ClaimsFactory.cs
	namespace 	
Webshop
 
. 
API 
. 

Extensions  
{ 
public 

class 
ClaimsFactory 
:  &
UserClaimsPrincipalFactory! ;
<; <
ApplicationUser< K
>K L
{ 
private 
readonly 
UserManager $
<$ %
ApplicationUser% 4
>4 5
_userManager6 B
;B C
public 
ClaimsFactory 
( 
UserManager 
< 
ApplicationUser '
>' (
userManager) 4
,4 5
IOptions 
< 
IdentityOptions $
>$ %
optionsAccessor& 5
)5 6
:7 8
base9 =
(= >
userManager> I
,I J
optionsAccessorK Z
)Z [
{ 	
_userManager 
= 
userManager &
;& '
} 	
	protected!! 
override!! 
async!!  
Task!!! %
<!!% &
ClaimsIdentity!!& 4
>!!4 5
GenerateClaimsAsync!!6 I
(!!I J
ApplicationUser!!J Y
user!!Z ^
)!!^ _
{"" 	
var## 
identity## 
=## 
await##  
base##! %
.##% &
GenerateClaimsAsync##& 9
(##9 :
user##: >
)##> ?
;##? @
var$$ 
roles$$ 
=$$ 
await$$ 
_userManager$$ *
.$$* +
GetRolesAsync$$+ 8
($$8 9
user$$9 =
)$$= >
;$$> ?
identity&& 
.&& 
	AddClaims&& 
(&& 
roles&& $
.&&$ %
Select&&% +
(&&+ ,
role&&, 0
=>&&1 3
new&&4 7
Claim&&8 =
(&&= >
JwtClaimTypes&&> K
.&&K L
Role&&L P
,&&P Q
role&&R V
)&&V W
)&&W X
)&&X Y
;&&Y Z
return(( 
identity(( 
;(( 
})) 	
}** 
}++ ≤	
~E:\Desktop\Szamitogep_biztonsag\Szamitogep-biztonsag-VIHIMA06\Webshop\Backend\Webshop.API\Extensions\ConfigurationExtension.cs
	namespace 	
Webshop
 
. 
API 
. 

Extensions  
{ 
public 

static 
class "
ConfigurationExtension .
{ 
public		 
static		 
void		 
AddConfigurations		 ,
(		, -
this		- 1
IServiceCollection		2 D
services		E M
,		M N
IConfiguration		O ]
configuration		^ k
)		k l
{

 	
services 
. 
	Configure 
<  
WebshopConfiguration 3
>3 4
(4 5
configuration5 B
.B C

GetSectionC M
(M N
$strN b
)b c
)c d
;d e
services 
. 
AddTransient !
<! "(
IWebshopConfigurationService" >
,> ?'
WebshopConfigurationService@ [
>[ \
(\ ]
)] ^
;^ _
} 	
} 
} √
zE:\Desktop\Szamitogep_biztonsag\Szamitogep-biztonsag-VIHIMA06\Webshop\Backend\Webshop.API\Extensions\ExceptionExtension.cs
	namespace 	
Webshop
 
. 
API 
. 

Extensions  
{ 
public		 

static		 
class		 
ExceptionExtension		 *
{

 
public 
static 
void "
AddExceptionExtensions 1
(1 2
this2 6
IServiceCollection7 I
servicesJ R
)R S
{ 	
services 
. 
AddProblemDetails &
(& '
options' .
=>/ 1
{ 
options 
. #
IncludeExceptionDetails /
=0 1
(2 3
ctx3 6
,6 7
ex8 :
): ;
=>< >
true? C
;C D
options 
. 
Map 
< #
EntityNotFoundException 3
>3 4
(4 5
( 
ctx 
, 
ex 
) 
=> 
{ 
var 
pd 
= $
StatusCodeProblemDetails 5
.5 6
Create6 <
(< =
StatusCodes= H
.H I
Status404NotFoundI Z
)Z [
;[ \
pd 
. 
Title 
= 
ex !
.! "
Message" )
;) *
return 
pd 
; 
} 
) 
; 
options 
. 
Map 
< %
InvalidParameterException 5
>5 6
(6 7
( 
ctx 
, 
ex 
) 
=> 
{ 
var 
pd 
= $
StatusCodeProblemDetails 5
.5 6
Create6 <
(< =
StatusCodes= H
.H I
Status400BadRequestI \
)\ ]
;] ^
pd 
. 
Title 
= 
ex !
.! "
Message" )
;) *
return   
pd   
;   
}!! 
)!! 
;!! 
options"" 
."" 
Map"" 
<"" $
ValidationErrorException"" 4
>""4 5
(""5 6
(## 
ctx## 
,## 
ex## 
)## 
=>## 
{$$ 
var%% 
pd%% 
=%% $
StatusCodeProblemDetails%% 5
.%%5 6
Create%%6 <
(%%< =
StatusCodes%%= H
.%%H I
Status400BadRequest%%I \
)%%\ ]
;%%] ^
pd&& 
.&& 
Title&& 
=&& 
ex&& !
.&&! "
Message&&" )
;&&) *
return'' 
pd'' 
;'' 
}(( 
)(( 
;(( 
})) 
))) 
;)) 
}** 	
}++ 
},, ÎK
yE:\Desktop\Szamitogep_biztonsag\Szamitogep-biztonsag-VIHIMA06\Webshop\Backend\Webshop.API\Extensions\IdentityExtension.cs
	namespace

 	
Webshop


 
.

 
API

 
.

 

Extensions

  
{ 
public 

static 
class 
IdentityExtension )
{ 
public 
static 
void !
AddIdentityExtensions 0
(0 1
this1 5
IServiceCollection6 H
servicesI Q
,Q R
IConfigurationS a
configurationb o
)o p
{ 	
services 
. 
AddIdentityCore $
<$ %
ApplicationUser% 4
>4 5
(5 6
)6 7
. 
AddRoles 
< 
ApplicationRole )
>) *
(* +
)+ ,
. $
AddEntityFrameworkStores )
<) *
WebshopDbContext* :
>: ;
(; <
)< =
. $
AddDefaultTokenProviders )
() *
)* +
. 
AddSignInManager !
(! "
)" #
. %
AddClaimsPrincipalFactory *
<* +
ClaimsFactory+ 8
>8 9
(9 :
): ;
;; <
services 
. 
AddIdentityServer &
(& '
options' .
=>/ 1
{   
options!! 
.!! 
Events!! 
.!! 
RaiseErrorEvents!! /
=!!0 1
true!!2 6
;!!6 7
options"" 
."" 
Events"" 
."" "
RaiseInformationEvents"" 5
=""6 7
true""8 <
;""< =
options## 
.## 
Events## 
.## 
RaiseFailureEvents## 1
=##2 3
true##4 8
;##8 9
options$$ 
.$$ 
Events$$ 
.$$ 
RaiseSuccessEvents$$ 1
=$$2 3
true$$4 8
;$$8 9
options%% 
.%% #
EmitStaticAudienceClaim%% /
=%%0 1
true%%2 6
;%%6 7
options&& 
.&& 
	IssuerUri&& !
=&&" #
configuration&&$ 1
.&&1 2
GetValue&&2 :
<&&: ;
string&&; A
>&&A B
(&&B C
$str&&C ]
)&&] ^
;&&^ _
}'' 
)'' 
.(( )
AddDeveloperSigningCredential(( .
(((. /
)((/ 0
.)) &
AddInMemoryPersistedGrants)) +
())+ ,
))), -
.** (
AddInMemoryIdentityResources** -
(**- . 
GetIdentityResources**. B
(**B C
)**C D
)**D E
.++  
AddInMemoryApiScopes++ %
(++% &
GetApiScopes++& 2
(++2 3
configuration++3 @
)++@ A
)++A B
.,, 
AddInMemoryClients,, #
(,,# $

GetClients,,$ .
(,,. /
configuration,,/ <
),,< =
),,= >
.-- #
AddInMemoryApiResources-- (
(--( )
new--) ,
List--- 1
<--1 2
ApiResource--2 =
>--= >
{.. 
new// 
ApiResource// #
(//# $
configuration00 %
.00% &
GetValue00& .
<00. /
string00/ 5
>005 6
(006 7
$str007 M
)00M N
,00N O
configuration11 %
.11% &
GetValue11& .
<11. /
string11/ 5
>115 6
(116 7
$str117 T
)11T U
,11U V
new22 
[22 
]22 
{22 
JwtClaimTypes22  -
.22- .
Role22. 2
,222 3

ClaimTypes224 >
.22> ?
Role22? C
}22D E
)33 
}44 
)44 
.55 
AddAspNetIdentity55 "
<55" #
ApplicationUser55# 2
>552 3
(553 4
)554 5
.66 %
AddResourceOwnerValidator66 *
<66* +>
2ResourceOwnerPasswordValidatorWithEmailAndUsername66+ ]
<66] ^
ApplicationUser66^ m
>66m n
>66n o
(66o p
)66p q
;66q r
}77 	
private99 
static99 
IEnumerable99 "
<99" #
IdentityResource99# 3
>993 4 
GetIdentityResources995 I
(99I J
)99J K
{:: 	
return;; 
new;; 
List;; 
<;; 
IdentityResource;; ,
>;;, -
{<< 
new== 
IdentityResources== %
.==% &
OpenId==& ,
(==, -
)==- .
,==. /
new>> 
IdentityResources>> %
.>>% &
Profile>>& -
(>>- .
)>>. /
,>>/ 0
new?? 
IdentityResources?? %
.??% &
Email??& +
(??+ ,
)??, -
,??- .
new@@ 
IdentityResource@@ $
{AA 
NameBB 
=BB 
	RoleTypesBB $
.BB$ %
	RoleScopeBB% .
,BB. /
DisplayNameCC 
=CC  !
$strCC" )
,CC) *

UserClaimsDD 
=DD  
{DD! "
JwtClaimTypesDD# 0
.DD0 1
RoleDD1 5
,DD5 6

ClaimTypesDD7 A
.DDA B
RoleDDB F
}DDG H
,DDH I#
ShowInDiscoveryDocumentEE +
=EE, -
trueEE. 2
,EE2 3
RequiredFF 
=FF 
trueFF #
,FF# $
	EmphasizeGG 
=GG 
trueGG  $
}HH 
}II 
;II 
}JJ 	
privateLL 
staticLL 
IEnumerableLL "
<LL" #
ApiScopeLL# +
>LL+ ,
GetApiScopesLL- 9
(LL9 :
IConfigurationLL: H
configurationLLI V
)LLV W
{MM 	
returnNN 
newNN 
ListNN 
<NN 
ApiScopeNN $
>NN$ %
{OO 
newPP 
ApiScopePP 
(PP 
configurationQQ !
.QQ! "
GetValueQQ" *
<QQ* +
stringQQ+ 1
>QQ1 2
(QQ2 3
$strQQ3 I
)QQI J
,QQJ K
configurationRR !
.RR! "
GetValueRR" *
<RR* +
stringRR+ 1
>RR1 2
(RR2 3
$strRR3 P
)RRP Q
,RRQ R
newSS 
stringSS 
[SS 
]SS  
{SS! "

ClaimTypesTT "
.TT" #
NameIdentifierTT# 1
,TT1 2
JwtClaimTypesUU %
.UU% &
NameUU& *
,UU* +

ClaimTypesVV "
.VV" #
RoleVV# '
,VV' (
JwtClaimTypesWW %
.WW% &
RoleWW& *
}XX 
)YY 
}ZZ 
;ZZ 
}[[ 	
private\\ 
static\\ 
IEnumerable\\ "
<\\" #
Client\\# )
>\\) *

GetClients\\+ 5
(\\5 6
IConfiguration\\6 D
configuration\\E R
)\\R S
{]] 	
return^^ 
new^^ 
List^^ 
<^^ 
Client^^ "
>^^" #
{__ 
new`` 
Client`` 
{aa 
ClientIdbb 
=bb 
configurationbb ,
.bb, -
GetValuebb- 5
<bb5 6
stringbb6 <
>bb< =
(bb= >
$strbb> W
)bbW X
,bbX Y
ClientSecretscc !
=cc" #
{cc$ %
newdd 
Secretdd "
(dd" #
configurationdd# 0
.dd0 1
GetValuedd1 9
<dd9 :
stringdd: @
>dd@ A
(ddA B
$strddB _
)dd_ `
.dd` a
Sha256dda g
(ddg h
)ddh i
)ddi j
}ee 
,ee 
AllowedGrantTypesff %
=ff& '

GrantTypesff( 2
.ff2 3!
ResourceOwnerPasswordff3 H
,ffH I
AllowedScopesgg !
=gg" #
newgg$ '
Listgg( ,
<gg, -
stringgg- 3
>gg3 4
{gg5 6#
IdentityServerConstantshh /
.hh/ 0
StandardScopeshh0 >
.hh> ?
OfflineAccesshh? L
,hhL M#
IdentityServerConstantsii /
.ii/ 0
StandardScopesii0 >
.ii> ?
OpenIdii? E
,iiE F#
IdentityServerConstantsjj /
.jj/ 0
StandardScopesjj0 >
.jj> ?
Profilejj? F
,jjF G
	RoleTypeskk !
.kk! "
	RoleScopekk" +
}ll 
.ll 
Concatll 
(ll 
configurationll *
.ll* +

GetSectionll+ 5
(ll5 6
$strll6 E
)llE F
.llF G
GetllG J
<llJ K
ListllK O
<llO P
stringllP V
>llV W
>llW X
(llX Y
)llY Z
)llZ [
.ll[ \
ToListll\ b
(llb c
)llc d
,lld e
AllowOfflineAccessmm &
=mm' (
truemm) -
,mm- ."
RefreshTokenExpirationnn *
=nn+ ,
TokenExpirationnn- <
.nn< =
Slidingnn= D
,nnD E"
AlwaysSendClientClaimsoo *
=oo+ ,
trueoo- 1
,oo1 2,
 UpdateAccessTokenClaimsOnRefreshpp 4
=pp5 6
truepp7 ;
}qq 
}rr 
;rr 
}ss 	
}tt 
}uu ∑;
öE:\Desktop\Szamitogep_biztonsag\Szamitogep-biztonsag-VIHIMA06\Webshop\Backend\Webshop.API\Extensions\ResourceOwnerPasswordValidatorWithEmailAndUsername.cs
	namespace 	
Webshop
 
. 
API 
. 

Extensions  
{		 
public 

class >
2ResourceOwnerPasswordValidatorWithEmailAndUsername C
<C D
TUserD I
>I J
:K L+
IResourceOwnerPasswordValidatorM l
where 
TUser 
: 
class 
{ 
private 
readonly 
SignInManager &
<& '
TUser' ,
>, -
_signInManager. <
;< =
private 
readonly 
IEventService &
_events' .
;. /
private 
readonly 
UserManager $
<$ %
TUser% *
>* +
_userManager, 8
;8 9
private 
readonly 
ILogger  
<  !>
2ResourceOwnerPasswordValidatorWithEmailAndUsername! S
<S T
TUserT Y
>Y Z
>Z [
_logger\ c
;c d
public >
2ResourceOwnerPasswordValidatorWithEmailAndUsername A
(A B
UserManager 
< 
TUser 
> 
userManager *
,* +
SignInManager 
< 
TUser 
>  
signInManager! .
,. /
IEventService   
events    
,    !
ILogger!! 
<!! >
2ResourceOwnerPasswordValidatorWithEmailAndUsername!! F
<!!F G
TUser!!G L
>!!L M
>!!M N
logger!!O U
)!!U V
{"" 	
_userManager## 
=## 
userManager## &
;##& '
_signInManager$$ 
=$$ 
signInManager$$ *
;$$* +
_events%% 
=%% 
events%% 
;%% 
_logger&& 
=&& 
logger&& 
;&& 
}'' 	
public.. 
virtual.. 
async.. 
Task.. !
ValidateAsync.." /
(../ 02
&ResourceOwnerPasswordValidationContext..0 V
context..W ^
)..^ _
{// 	
var00 
user00 
=00 
await00 
_userManager00 )
.00) *
FindByNameAsync00* 9
(009 :
context00: A
.00A B
UserName00B J
)00J K
;00K L
user11 
??=11 
await11 
_userManager11 '
.11' (
FindByEmailAsync11( 8
(118 9
context119 @
.11@ A
UserName11A I
)11I J
;11J K
if33 
(33 
user33 
!=33 
null33 
)33 
{44 
var55 
result55 
=55 
await55 "
_signInManager55# 1
.551 2$
CheckPasswordSignInAsync552 J
(55J K
user55K O
,55O P
context55Q X
.55X Y
Password55Y a
,55a b
true55c g
)55g h
;55h i
if66 
(66 
result66 
.66 
	Succeeded66 $
)66$ %
{77 
var88 
sub88 
=88 
await88 #
_userManager88$ 0
.880 1
GetUserIdAsync881 ?
(88? @
user88@ D
)88D E
;88E F
_logger:: 
.:: 
LogInformation:: *
(::* +
$str::+ Q
,::Q R
context::S Z
.::Z [
UserName::[ c
)::c d
;::d e
await;; 
_events;; !
.;;! "

RaiseAsync;;" ,
(;;, -
new;;- 0!
UserLoginSuccessEvent;;1 F
(;;F G
context;;G N
.;;N O
UserName;;O W
,;;W X
sub;;Y \
,;;\ ]
context;;^ e
.;;e f
UserName;;f n
,;;n o
interactive;;p {
:;;{ |
false	;;} Ç
)
;;Ç É
)
;;É Ñ
;
;;Ñ Ö
context== 
.== 
Result== "
===# $
new==% (!
GrantValidationResult==) >
(==> ?
sub==? B
,==B C!
AuthenticationMethods==D Y
.==Y Z
Password==Z b
)==b c
;==c d
return>> 
;>> 
}?? 
else@@ 
if@@ 
(@@ 
result@@ 
.@@  
IsLockedOut@@  +
)@@+ ,
{AA 
_loggerBB 
.BB 
LogInformationBB *
(BB* +
$strBB+ e
,BBe f
contextBBg n
.BBn o
UserNameBBo w
)BBw x
;BBx y
awaitCC 
_eventsCC !
.CC! "

RaiseAsyncCC" ,
(CC, -
newCC- 0!
UserLoginFailureEventCC1 F
(CCF G
contextCCG N
.CCN O
UserNameCCO W
,CCW X
$strCCY e
,CCe f
interactiveCCg r
:CCr s
falseCCt y
)CCy z
)CCz {
;CC{ |
}DD 
elseEE 
ifEE 
(EE 
resultEE 
.EE  
IsNotAllowedEE  ,
)EE, -
{FF 
_loggerGG 
.GG 
LogInformationGG *
(GG* +
$strGG+ f
,GGf g
contextGGh o
.GGo p
UserNameGGp x
)GGx y
;GGy z
awaitHH 
_eventsHH !
.HH! "

RaiseAsyncHH" ,
(HH, -
newHH- 0!
UserLoginFailureEventHH1 F
(HHF G
contextHHG N
.HHN O
UserNameHHO W
,HHW X
$strHHY f
,HHf g
interactiveHHh s
:HHs t
falseHHu z
)HHz {
)HH{ |
;HH| }
}II 
elseJJ 
{KK 
_loggerLL 
.LL 
LogInformationLL *
(LL* +
$strLL+ n
,LLn o
contextLLp w
.LLw x
UserName	LLx Ä
)
LLÄ Å
;
LLÅ Ç
awaitMM 
_eventsMM !
.MM! "

RaiseAsyncMM" ,
(MM, -
newMM- 0!
UserLoginFailureEventMM1 F
(MMF G
contextMMG N
.MMN O
UserNameMMO W
,MMW X
$strMMY n
,MMn o
interactiveMMp {
:MM{ |
false	MM} Ç
)
MMÇ É
)
MMÉ Ñ
;
MMÑ Ö
}NN 
}OO 
elsePP 
{QQ 
_loggerRR 
.RR 
LogInformationRR &
(RR& '
$strRR' J
,RRJ K
contextRRL S
.RRS T
UserNameRRT \
)RR\ ]
;RR] ^
awaitSS 
_eventsSS 
.SS 

RaiseAsyncSS (
(SS( )
newSS) ,!
UserLoginFailureEventSS- B
(SSB C
contextSSC J
.SSJ K
UserNameSSK S
,SSS T
$strSSU q
,SSq r
interactiveSSs ~
:SS~ 
false
SSÄ Ö
)
SSÖ Ü
)
SSÜ á
;
SSá à
}TT 
contextUU 
.UU 
ResultUU 
=UU 
newUU  !
GrantValidationResultUU! 6
(UU6 7
TokenRequestErrorsUU7 I
.UUI J
InvalidGrantUUJ V
)UUV W
;UUW X
}VV 	
}WW 
}XX ë'
yE:\Desktop\Szamitogep_biztonsag\Szamitogep-biztonsag-VIHIMA06\Webshop\Backend\Webshop.API\Extensions\RoleSeedExtension.cs
	namespace 	
Webshop
 
. 
API 
. 

Extensions  
{ 
public

 

static

 
class

 
RoleSeedExtension

 )
{ 
private 
class 
UserRoleHelper $
{ 	
public 
ApplicationUser "
?" #
UserDTO$ +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
string 
Role 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
string/ 5
.5 6
Empty6 ;
;; <
} 	
public 
async 
static 
Task  *
AddRoleSeedExtensionExtensions! ?
(? @
this@ D
IServiceProviderE U
servicesV ^
,^ _
IConfiguration` n
configurationo |
)| }
{ 	
using 
( 
var 
scope 
= 
services '
.' (
CreateScope( 3
(3 4
)4 5
)5 6
{ 
var 
roleManager 
=  !
scope" '
.' (
ServiceProvider( 7
.7 8
GetRequiredService8 J
<J K
RoleManagerK V
<V W
ApplicationRoleW f
>f g
>g h
(h i
)i j
;j k
var 
userManager 
=  !
scope" '
.' (
ServiceProvider( 7
.7 8
GetRequiredService8 J
<J K
UserManagerK V
<V W
ApplicationUserW f
>f g
>g h
(h i
)i j
;j k
var 
roles 
= 
configuration )
.) *

GetSection* 4
(4 5
$str5 <
)< =
.= >
Get> A
<A B
ListB F
<F G
ApplicationRoleG V
>V W
>W X
(X Y
)Y Z
;Z [
foreach 
( 
var 
role !
in" $
roles% *
)* +
{   
var!! 
alreadyExists!! %
=!!& '
await!!( -
roleManager!!. 9
.!!9 :
RoleExistsAsync!!: I
(!!I J
role!!J N
.!!N O
Name!!O S
)!!S T
;!!T U
if"" 
("" 
!"" 
alreadyExists"" &
)""& '
{## 
await$$ 
roleManager$$ )
.$$) *
CreateAsync$$* 5
($$5 6
role$$6 :
)$$: ;
;$$; <
}%% 
}&& 
var'' 
	userRoles'' 
='' 
configuration''  -
.''- .

GetSection''. 8
(''8 9
$str''9 G
)''G H
.''H I
Get''I L
<''L M
List''M Q
<''Q R
UserRoleHelper''R `
>''` a
>''a b
(''b c
)''c d
;''d e
var(( 
secretPW(( 
=(( 
configuration(( ,
.((, -
GetValue((- 5
<((5 6
string((6 <
>((< =
(((= >
$str((> I
)((I J
;((J K
foreach)) 
()) 
var)) 
userRole)) %
in))& (
	userRoles))) 2
)))2 3
{** 
var++ 
alreadyExists++ %
=++& '
(++( )
await++) .
userManager++/ :
.++: ;
FindByNameAsync++; J
(++J K
userRole++K S
.++S T
UserDTO++T [
?++[ \
.++\ ]
UserName++] e
)++e f
)++f g
!=++h j
null++k o
;++o p
if,, 
(,, 
!,, 
alreadyExists,, &
),,& '
{-- 
IdentityResult.. &
checkAdd..' /
=..0 1
await..2 7
userManager..8 C
...C D
CreateAsync..D O
(..O P
userRole..P X
...X Y
UserDTO..Y `
,..` a
secretPW..b j
)..j k
;..k l
if// 
(// 
checkAdd// $
.//$ %
	Succeeded//% .
)//. /
{00 
await11 !
userManager11" -
.11- .
AddToRoleAsync11. <
(11< =
userRole11= E
.11E F
UserDTO11F M
,11M N
userRole11O W
.11W X
Role11X \
)11\ ]
;11] ^
}22 
}33 
}44 
}55 
}66 	
}77 
}88 ô;
xE:\Desktop\Szamitogep_biztonsag\Szamitogep-biztonsag-VIHIMA06\Webshop\Backend\Webshop.API\Extensions\ServiceExtension.cs
	namespace 	
Webshop
 
. 
API 
. 

Extensions  
{ 
public 

static 
class 
ServiceExtension (
{ 
public 
static 
void  
AddServiceExtensions /
(/ 0
this0 4
IServiceCollection5 G
servicesH P
)P Q
{ 	
services 
. 
AddHttpClient "
(" #
)# $
;$ %
services 
. 
AddTransient !
<! "

IUserStore" ,
,, -
	UserStore. 7
>7 8
(8 9
)9 :
;: ;
services 
. 
AddTransient !
<! "
IRequestHandler" 1
<1 2
CreateUserCommand2 C
,C D
boolE I
>I J
,J K
UserCommandHandlerL ^
>^ _
(_ `
)` a
;a b
services 
. 
AddTransient !
<! "
IRequestHandler" 1
<1 2
EditUserCommand2 A
,A B
boolC G
>G H
,H I
UserCommandHandlerJ \
>\ ]
(] ^
)^ _
;_ `
services 
. 
AddTransient !
<! "
IRequestHandler" 1
<1 2
EditUserRoleCommand2 E
,E F
UnitG K
>K L
,L M
UserCommandHandlerN `
>` a
(a b
)b c
;c d
services   
.   
AddTransient   !
<  ! "
IRequestHandler  " 1
<  1 2 
GetActualUserIdQuery  2 F
,  F G
string  H N
?  N O
>  O P
,  P Q
UserQueryHandler  R b
>  b c
(  c d
)  d e
;  e f
services!! 
.!! 
AddTransient!! !
<!!! "
IRequestHandler!!" 1
<!!1 2
GetUserQuery!!2 >
,!!> ?$
ProfileWithNameViewModel!!@ X
>!!X Y
,!!Y Z
UserQueryHandler!![ k
>!!k l
(!!l m
)!!m n
;!!n o
services"" 
."" 
AddTransient"" !
<""! "
IRequestHandler""" 1
<""1 2
GetProfileQuery""2 A
,""A B
ProfileViewModel""C S
>""S T
,""T U
UserQueryHandler""V f
>""f g
(""g h
)""h i
;""i j
services## 
.## 
AddTransient## !
<##! "
IRequestHandler##" 1
<##1 2
GetFullProfileQuery##2 E
,##E F$
ProfileWithNameViewModel##G _
>##_ `
,##` a
UserQueryHandler##b r
>##r s
(##s t
)##t u
;##u v
services$$ 
.$$ 
AddTransient$$ !
<$$! "
IRequestHandler$$" 1
<$$1 2
GetUsersByRoleQuery$$2 E
,$$E F
IEnumerable$$G R
<$$R S
UserNameViewModel$$S d
>$$d e
>$$e f
,$$f g
UserQueryHandler$$h x
>$$x y
($$y z
)$$z {
;$${ |
services&& 
.&& 
AddTransient&& !
<&&! "
IRequestHandler&&" 1
<&&1 2 
GetCaffDownloadQuery&&2 F
,&&F G
byte&&H L
[&&L M
]&&M N
>&&N O
,&&O P
CaffQueryHandler&&Q a
>&&a b
(&&b c
)&&c d
;&&d e
services'' 
.'' 
AddTransient'' !
<''! "
IRequestHandler''" 1
<''1 2
GetCaffDetailsQuery''2 E
,''E F 
CaffDetailsViewModel''G [
>''[ \
,''\ ]
CaffQueryHandler''^ n
>''n o
(''o p
)''p q
;''q r
services(( 
.(( 
AddTransient(( !
<((! "
IRequestHandler((" 1
<((1 2
GetCaffListQuery((2 B
,((B C(
EnumerableWithTotalViewModel((D `
<((` a
CaffListViewModel((a r
>((r s
>((s t
,((t u
CaffQueryHandler	((v Ü
>
((Ü á
(
((á à
)
((à â
;
((â ä
services)) 
.)) 
AddTransient)) !
<))! "
IRequestHandler))" 1
<))1 2
GetBoughtCaffsQuery))2 E
,))E F(
EnumerableWithTotalViewModel))G c
<))c d
CaffListViewModel))d u
>))u v
>))v w
,))w x
CaffQueryHandler	))y â
>
))â ä
(
))ä ã
)
))ã å
;
))å ç
services++ 
.++ 
AddTransient++ !
<++! "
IRequestHandler++" 1
<++1 2 
RemoveCommentCommand++2 F
,++F G
Unit++H L
>++L M
,++M N
CaffCommandHandler++O a
>++a b
(++b c
)++c d
;++d e
services,, 
.,, 
AddTransient,, !
<,,! "
IRequestHandler,," 1
<,,1 2
PostCommentCommand,,2 D
,,,D E
Unit,,F J
>,,J K
,,,K L
CaffCommandHandler,,M _
>,,_ `
(,,` a
),,a b
;,,b c
services-- 
.-- 
AddTransient-- !
<--! "
IRequestHandler--" 1
<--1 2
UploadCaffCommand--2 C
,--C D
Guid--E I
>--I J
,--J K
CaffCommandHandler--L ^
>--^ _
(--_ `
)--` a
;--a b
services.. 
... 
AddTransient.. !
<..! "
IRequestHandler.." 1
<..1 2
DeleteCaffCommand..2 C
,..C D
Unit..E I
>..I J
,..J K
CaffCommandHandler..L ^
>..^ _
(.._ `
)..` a
;..a b
services// 
.// 
AddTransient// !
<//! "
IRequestHandler//" 1
<//1 2
BuyCaffCommand//2 @
,//@ A
Unit//B F
>//F G
,//G H
CaffCommandHandler//I [
>//[ \
(//\ ]
)//] ^
;//^ _
services00 
.00 
AddTransient00 !
<00! "
IRequestHandler00" 1
<001 2
EditCaffDataCommand002 E
,00E F
Unit00G K
>00K L
,00L M
CaffCommandHandler00N `
>00` a
(00a b
)00b c
;00c d
services22 
.22 
AddTransient22 !
(22! "
typeof22" (
(22( )
IGenericRepository22) ;
<22; <
>22< =
)22= >
,22> ?
typeof22@ F
(22F G
GenericRepository22G X
<22X Y
>22Y Z
)22Z [
)22[ \
;22\ ]
services33 
.33 
AddTransient33 !
<33! "
IUnitOfWork33" -
,33- .

UnitOfWork33/ 9
>339 :
(33: ;
)33; <
;33< =
services44 
.44 
AddTransient44 !
<44! "
IFileRepository44" 1
,441 2
FileRepository443 A
>44A B
(44B C
)44C D
;44D E
}55 	
}66 
}77 ™4
xE:\Desktop\Szamitogep_biztonsag\Szamitogep-biztonsag-VIHIMA06\Webshop\Backend\Webshop.API\Extensions\SwaggerExtension.cs
	namespace 	
Webshop
 
. 
API 
. 

Extensions  
{		 
public 

static 
class 
SwaggerExtension (
{ 
public 
static 
void 
AddSwaggerExtension .
(. /
this/ 3
IServiceCollection4 F
servicesG O
,O P
IConfigurationQ _
configuration` m
)m n
{ 	
services 
. 
AddSwaggerGen "
(" #
options# *
=>+ -
{ 
options 
. 

SwaggerDoc "
(" #
$str# '
,' (
new) ,
OpenApiInfo- 8
{9 :
Title; @
=A B
configurationC P
.P Q
GetValueQ Y
<Y Z
stringZ `
>` a
(a b
$strb s
)s t
,t u
Versionv }
=~ 
$str
Ä Ñ
}
Ö Ü
)
Ü á
;
á à
options 
. !
AddSecurityDefinition -
(- .
configuration. ;
.; <
GetValue< D
<D E
stringE K
>K L
(L M
$strM l
)l m
,m n
newo r"
OpenApiSecurityScheme	s à
{ 
Type 
= 
SecuritySchemeType -
.- .
OAuth2. 4
,4 5
Flows 
= 
new 
OpenApiOAuthFlows  1
{ 
Password  
=! "
new# &
OpenApiOAuthFlow' 7
(7 8
)8 9
{   
TokenUrl!! $
=!!% &
new!!' *
Uri!!+ .
(!!. /
configuration!!/ <
.!!< =
GetValue!!= E
<!!E F
string!!F L
>!!L M
(!!M N
$str!!N h
)!!h i
+!!j k
$str!!l |
)!!| }
,!!} ~
Scopes"" "
=""# $
new""% (

Dictionary"") 3
<""3 4
string""4 :
,"": ;
string""< B
>""B C
{""D E
{##  !
configuration##" /
.##/ 0
GetValue##0 8
<##8 9
string##9 ?
>##? @
(##@ A
$str##A W
)##W X
,##X Y
configuration$$$ 1
.$$1 2
GetValue$$2 :
<$$: ;
string$$; A
>$$A B
($$B C
$str$$C `
)$$` a
}$$b c
}%% 
}&& 
}'' 
,'' 
In(( 
=(( 
ParameterLocation(( *
.((* +
Header((+ 1
,((1 2
Name)) 
=)) 
$str)) *
,))* +
Scheme** 
=** 
$str** %
}++ 
)++ 
;++ 
options,, 
.,, 
OperationFilter,, '
<,,' (+
AuthorizeSwaggerOperationFilter,,( G
>,,G H
(,,H I
new,,I L&
OpenApiSecurityRequirement,,M g
(,,g h
),,h i
{-- 
{.. 
new// !
OpenApiSecurityScheme// 1
(//1 2
)//2 3
{00 
	Reference11 %
=11& '
new11( +
OpenApiReference11, <
(11< =
)11= >
{22 
Id33  "
=33# $
configuration33% 2
.332 3
GetValue333 ;
<33; <
string33< B
>33B C
(33C D
$str33D c
)33c d
,33d e
Type44  $
=44% &
ReferenceType44' 4
.444 5
SecurityScheme445 C
}55 
}66 
,66 
new77 
List77  
<77  !
string77! '
>77' (
(77( )
)77) *
{77* +
configuration77, 9
.779 :
GetValue77: B
<77B C
string77C I
>77I J
(77J K
$str77K U
)77U V
}77W X
}88 
}99 
)99 
;99 
}:: 
):: 
;:: 
};; 	
}<< 
publicAA 

classAA +
AuthorizeSwaggerOperationFilterAA 0
:AA1 2
IOperationFilterAA3 C
{BB 
privateCC 
readonlyCC &
OpenApiSecurityRequirementCC 3
requirementCC4 ?
;CC? @
publicII +
AuthorizeSwaggerOperationFilterII .
(II. /&
OpenApiSecurityRequirementII/ I
requirementIIJ U
)IIU V
{JJ 	
thisKK 
.KK 
requirementKK 
=KK 
requirementKK *
;KK* +
}LL 	
publicSS 
voidSS 
ApplySS 
(SS 
OpenApiOperationSS *
	operationSS+ 4
,SS4 5"
OperationFilterContextSS6 L
contextSSM T
)SST U
{TT 	
ifUU 
(UU 
contextUU 
.UU 

MethodInfoUU "
.UU" #
GetCustomAttributeUU# 5
<UU5 6
AuthorizeAttributeUU6 H
>UUH I
(UUI J
)UUJ K
!=UUL N
nullUUO S
||UUT V
contextVV 
.VV 

MethodInfoVV "
.VV" #
DeclaringTypeVV# 0
?VV0 1
.VV1 2
GetCustomAttributeVV2 D
<VVD E
AuthorizeAttributeVVE W
>VVW X
(VVX Y
)VVY Z
!=VV[ ]
nullVV^ b
)VVb c
{WW 
	operationXX 
.XX 
SecurityXX "
.XX" #
AddXX# &
(XX& '
requirementXX' 2
)XX2 3
;XX3 4
	operationYY 
.YY 
	ResponsesYY #
.YY# $
TryAddYY$ *
(YY* +
$strYY+ 0
,YY0 1
newYY2 5
OpenApiResponseYY6 E
(YYE F
)YYF G
{YYH I
DescriptionYYJ U
=YYV W
$strYYX f
}YYg h
)YYh i
;YYi j
	operationZZ 
.ZZ 
	ResponsesZZ #
.ZZ# $
TryAddZZ$ *
(ZZ* +
$strZZ+ 0
,ZZ0 1
newZZ2 5
OpenApiResponseZZ6 E
(ZZE F
)ZZF G
{ZZH I
DescriptionZZJ U
=ZZV W
$strZZX c
}ZZd e
)ZZe f
;ZZf g
}[[ 
}\\ 	
}]] 
}^^ “J
dE:\Desktop\Szamitogep_biztonsag\Szamitogep-biztonsag-VIHIMA06\Webshop\Backend\Webshop.API\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
new+ .!
WebApplicationOptions/ D
{ 
Args 
=	 

args 
, 
WebRootPath 
= 
$str 
} 
) 
; 
ConfigurationManager 
configuration "
=# $
builder% ,
., -
Configuration- :
;: ;
builder 
. 
Services 
. 
AddDbContext 
< 
WebshopDbContext .
>. /
(/ 0
options0 7
=>8 :
{ 
options 
. 
UseSqlServer 
( 
configuration &
.& '
GetConnectionString' :
(: ;
$str; N
)N O
,O P
optQ T
=>U W
{ 
opt 
.  
EnableRetryOnFailure  
(  !
)! "
;" #
} 
) 
. &
EnableSensitiveDataLogging !
(! "
)" #
;# $
} 
) 
; 
builder 
. 
Services 
. 
	AddScoped 
< '
IUserClaimsPrincipalFactory 6
<6 7
ApplicationUser7 F
>F G
,G H
ClaimsFactoryI V
>V W
(W X
)X Y
;Y Z
builder 
. 
Services 
. #
AddAutoMapperExtensions (
(( )
)) *
;* +
builder 
. 
Services 
. "
AddExceptionExtensions '
(' (
)( )
;) *
builder   
.   
Services   
.   !
AddIdentityExtensions   &
(  & '
configuration  ' 4
)  4 5
;  5 6
builder"" 
."" 
Services"" 
."" '
AddAuthenticationExtensions"" ,
("", -
configuration""- :
)"": ;
;""; <
builder$$ 
.$$ 
Services$$ 
.$$  
AddServiceExtensions$$ %
($$% &
)$$& '
;$$' (
builder%% 
.%% 
Services%% 
.%% 
AddConfigurations%% "
(%%" #
configuration%%# 0
)%%0 1
;%%1 2
builder&& 
.&& 
Services&& 
.&& 
AddSwaggerExtension&& $
(&&$ %
configuration&&% 2
)&&2 3
;&&3 4
builder(( 
.(( 
Services(( 
.(( 

AddMediatR(( 
((( 
typeof(( "
(((" #
Program((# *
)((* +
.((+ ,
Assembly((, 4
)((4 5
;((5 6
builder)) 
.)) 
Services)) 
.)) 
AddControllers)) 
())  
)))  !
;))! "
builder++ 
.++ 
Services++ 
.++ #
AddEndpointsApiExplorer++ (
(++( )
)++) *
;++* +
var-- 
app-- 
=-- 	
builder--
 
.-- 
Build-- 
(-- 
)-- 
;-- 
builder// 
.// 
Configuration// 
.00 
SetBasePath00 
(00 
app00 
.00 
Environment00  
.00  !
ContentRootPath00! 0
)000 1
.11 
AddJsonFile11 
(11 
$str11 #
,11# $
true11% )
,11) *
true11+ /
)11/ 0
.22 
AddJsonFile22 
(22 
$"22 
$str22 
{22  
app22  #
.22# $
Environment22$ /
.22/ 0
EnvironmentName220 ?
}22? @
$str22@ E
"22E F
,22F G
true22H L
,22L M
true22N R
)22R S
;22S T
using44 
(44 
var44 

scope44 
=44 
app44 
.44 
Services44 
.44  
CreateScope44  +
(44+ ,
)44, -
)44- .
{55 
var66 
	dbContext66 
=66 
scope66 
.66 
ServiceProvider66 )
.66) *
GetRequiredService66* <
<66< =
WebshopDbContext66= M
>66M N
(66N O
)66O P
;66P Q
	dbContext77 
.77 
Database77 
.77 
Migrate77 
(77 
)77  
;77  !
}88 
app:: 
.:: 
UseProblemDetails:: 
(:: 
):: 
;:: 
if== 
(== 
app== 
.== 
Environment== 
.== 
IsDevelopment== !
(==! "
)==" #
)==# $
{>> 
app?? 
.?? 

UseSwagger?? 
(?? 
)?? 
;?? 
app@@ 
.@@ 
UseSwaggerUI@@ 
(@@ 
options@@ 
=>@@ 
{AA 
optionsBB 
.BB 
SwaggerEndpointBB 
(BB  
$strBB  :
,BB: ;
configurationBB< I
.BBI J
GetValueBBJ R
<BBR S
stringBBS Y
>BBY Z
(BBZ [
$strBB[ p
)BBp q
)BBq r
;BBr s
optionsCC 
.CC 
OAuthClientIdCC 
(CC 
configurationCC +
.CC+ ,
GetValueCC, 4
<CC4 5
stringCC5 ;
>CC; <
(CC< =
$strCC= V
)CCV W
)CCW X
;CCX Y
optionsDD 
.DD 
OAuthClientSecretDD !
(DD! "
configurationDD" /
.DD/ 0
GetValueDD0 8
<DD8 9
stringDD9 ?
>DD? @
(DD@ A
$strDDA ^
)DD^ _
)DD_ `
;DD` a
optionsEE 
.EE 
OAuthAppNameEE 
(EE 
configurationEE *
.EE* +
GetValueEE+ 3
<EE3 4
stringEE4 :
>EE: ;
(EE; <
$strEE< Q
)EEQ R
)EER S
;EES T
optionsFF 
.FF 
OAuthUsePkceFF 
(FF 
)FF 
;FF 
}GG 
)GG 
;GG 
}HH 
appII 
.II 
UseHttpsRedirectionII 
(II 
)II 
;II 
varJJ 
configServiceJJ 
=JJ 
appJJ 
.JJ 
ServicesJJ  
.JJ  !
GetRequiredServiceJJ! 3
<JJ3 4(
IWebshopConfigurationServiceJJ4 P
>JJP Q
(JJQ R
)JJR S
;JJS T
appKK 
.KK 
UseWhenKK 
(KK 
contextLL 
=>LL 
!LL 
contextLL 
.LL 
RequestLL 
.LL  
PathLL  $
.LL$ %
StartsWithSegmentsLL% 7
(LL7 8
$"LL8 :
$strLL: ;
{LL; <
configServiceLL< I
.LLI J$
GetStaticFileRequestPathLLJ b
(LLb c
)LLc d
}LLd e
$strLLe f
{LLf g
configServiceLLg t
.LLt u!
GetCaffsSubdirectory	LLu â
(
LLâ ä
)
LLä ã
}
LLã å
"
LLå ç
)
LLç é
,
LLé è

appBuilderMM 
=>MM 

appBuilderNN 
.NN 
UseStaticFilesNN !
(NN! "
newNN" %
StaticFileOptionsNN& 7
{OO 	
FileProviderPP 
=PP 
newPP  
PhysicalFileProviderPP 3
(PP3 4
$"PP4 6
{PP6 7
configServicePP7 D
.PPD E%
GetStaticFilePhysicalPathPPE ^
(PP^ _
)PP_ `
}PP` a
"PPa b
)PPb c
,PPc d
RequestPathQQ 
=QQ 
$"QQ 
$strQQ 
{QQ 
configServiceQQ +
.QQ+ ,$
GetStaticFileRequestPathQQ, D
(QQD E
)QQE F
}QQF G
"QQG H
}RR 	
)RR	 

)RR
 
;RR 
appSS 
.SS 

UseRoutingSS 
(SS 
)SS 
;SS 
appTT 
.TT 
UseCorsTT 
(TT 
$strTT 
)TT 
;TT 
appUU 
.UU 
UseIdentityServerUU 
(UU 
)UU 
;UU 
appVV 
.VV 
UseAuthorizationVV 
(VV 
)VV 
;VV 
appXX 
.XX 
UseEndpointsXX 
(XX 
	endpointsXX 
=>XX 
{YY 
	endpointsZZ 
.ZZ 
MapControllersZZ 
(ZZ 
)ZZ 
;ZZ 
}[[ 
)[[ 
;[[ 
app]] 
.]] 
Services]] 
.]] *
AddRoleSeedExtensionExtensions]] +
(]]+ ,
configuration]], 9
)]]9 :
;]]: ;
app__ 
.__ 
Run__ 
(__ 
)__ 	
;__	 
