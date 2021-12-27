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

***新會員 Email 確認功能***

[V] 會員按下email裡的確認連結 , MembersController.ConfirmRegister(), Service.ActiveRegister()
[V] Views / Members / ConfirmRegister
[V] modify IMemberRepository  add Load(), ActiveRegister()
[V] modify MemberRepository  add Load(), ActiveRegister()
[V] modify MemberService . ActiveRegister

***password 要編碼***

[V] add new / Models / Infrastructures / HashUtility.cs
[V] 修改MemberEntity, add EnctryptedPassword property
[V] 修改MemberRepository, 改成取用 EncryptedPassword property
[V] 修改Members table, column Password, feom nvarchar(50) to nvarchar(70)
[V] 同步修改 / Models / EFModels / Members.cs 裡的 Password data annotation

***登入/登出網站***

[working on] modify web.config, add authenthcation node
[working on] modify MemberController . About , add " Authorize " attribute
[working on] add MembersController.Logout()
[working on] add / Models / ViewModels / LoginVM.cs
[working on] add MembersController.Login(),and create "Login" view page
[working on] add / Models / DTOs / LoginResponse.cs
[working on] add MemberRepository.Login(account)
[working on] add MemberService.Login(account,password)
[working on] add MemberController.Login() httppost action 使用表單驗證，寫入 cookie

[working on] modify _Layout page, add " Login / logout " links 




[]發信還沒寫

[] implement RegisterCommamd.Execute()
[] implement MemberService.CreateNewMember()
[] add SendEmail Utility (at / Models / Infrastructures / EmailHelper.cs)