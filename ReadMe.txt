[V] Create BookStore db,Member table
[V] Create NTUB.BookStore.site mvc project

[V] Add / Models / ViewModels / RegisterVM.cs
[V] Creat "MembersContrroller",with "Register" action, and view page
[V] remove "EF zh-hant" package, rebuild project

[V] add / Models / UseCases / RegisterRequest, RegisterResponse class
[V] add / Models / Entities / RegisterEntity class 
[V] add / Models / UseCases / RegisterCommand class (with Execute method)
[V] add / Models / Core / MemberService class (with CreateNewMember method)
[V] implement MemberController.Register() function
[V] implement RegisterCommand.Execute function

[V] add new / Models / Infrastructures / Repositories / MemberRepository

***�s�|�� Email �T�{�\��***

[V] �|�����Uemail�̪��T�{�s�� , MembersController.ConfirmRegister(), Service.ActiveRegister()
[V] Views / Members / ConfirmRegister
[V] modify IMemberRepository  add Load(), ActiveRegister()
[V] modify MemberRepository  add Load(), ActiveRegister()
[V] modify MemberService . ActiveRegister

***password �n�s�X***

[V] add new / Models / Infrastructures / HashUtility.cs
[V] �ק�MemberEntity, add EnctryptedPassword property
[V] �ק�MemberRepository, �令���� EncryptedPassword property
[V] �ק�Members table, column Password, feom nvarchar(50) to nvarchar(70)
[V] �P�B�ק� / Models / EFModels / Members.cs �̪� Password data annotation

***�n�J/�n�X����***

[V] modify web.config, add authenthcation node
[V] modify MemberController . About , add " Authorize " attribute
[V] add MembersController.Logout()
[V] add / Models / ViewModels / LoginVM.cs
[V] add MembersController.Login(),and create "Login" view page
[V] add / Models / DTOs / LoginResponse.cs
[V] add MemberRepository.Login(account)
[V] add MemberService.Login(account,password)
[V] add MemberController.Login() httppost action �ϥΪ�����ҡA�g�J cookie

[V] modify _Layout page, add " Login / logout " links 

***�|������***

[]�ק�ӤH�򥻸��
[]�ܧ�K�X


[]�o�H�٨S�g
[] add SendEmail Utility (at / Models / Infrastructures / EmailHelper.cs)

[]�ѰO�K�X