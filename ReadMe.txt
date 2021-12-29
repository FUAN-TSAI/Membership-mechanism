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

[V] modify web.config, add authenthcation node
[V] modify MemberController . About , add " Authorize " attribute
[V] add MembersController.Logout()
[V] add / Models / ViewModels / LoginVM.cs
[V] add MembersController.Login(),and create "Login" view page
[V] add / Models / DTOs / LoginResponse.cs
[V] add MemberRepository.Login(account)
[V] add MemberService.Login(account,password)
[V] add MemberController.Login() httppost action 使用表單驗證，寫入 cookie

[V] modify _Layout page, add " Login / logout " links 

***會員中心***

[V] 會員中心頁( / Members / Index )

	[] 改 web.config
	[] add MmeberController . Index(), Index view page

[V] 修改個人基本資料( / Members / EditProfile /)

	[] add / ViewModels / EditProfileVM.cs (Id/Account/Name/Email/Mobile)
	[] add / MembersController . EditProfile(),add " EditProfile " view page(修改view page)
	[] 寫 MembersController . EditProfile(),
	[] 新增 / Models / ViewModels / EditProfileVM (ToEditProfileVM擴充方法)
	[] add / Models / DTOs / UpdateProfileRequest class(Id/Account/Name/Email/Mobile) 
	[] 寫 MembersController . EditProfile(EditProfileVM model)
	[] UpdateProfileRequest class 加入 string " CurrentUserAccount " property
	[] add MemberService.UpdateProfile(UpdateProfileRequest)
	[] modify IMemberRepository => add IsExists(account,excluedId),Update(MemberEntity)
	[] 如果更新個資成功，且有改帳號，就自動轉向到 logout page

[V] 變更密碼(/ Members / ResetPassword /)
	[] add / ViewModels / EditPasswordVM
	[] add / MembersController . EditPassword(),add " EditPassword " view page
	[] add / Models / DTOs / ChangePasswordRequest class (CurrentUserAccount/NewPassword/OriginalPassword)
	[] 寫 MembersController . EditPassword(EditPasswordVM model)
	[] add MemberService.ChangePasswordt(ChangePasswordRequest)
	[] add IMemberRepository . UpdatePassword()

[V] /Member / Index / , EditProfile, EditPassword, Logout 要加 [Authorize] 


[V]發信
	[] add SendEmail Utility (at / Models / Infrastructures / EmailHelper.cs)

[working on]忘記密碼
	[] add / Views / Login.cshtml (忘記密碼的超連結)
	[] add / Models / ViewModels / ForgetPasswordVM 
	[] add / MembersController . ForgetPassword(), add " ForgetPassword " view page
	[] 寫 MembersController . ForgetPassword(ForgetPasswordVM model)
	[] add / Views / ConfirmForgetPassword.cshtml
	[] add MemberService . RequestResetPassword(string account, string email, string urlTemplate)
	[] MembersController . ForgetPassword(ForgetPasswordVM model)加入回傳網址
	[] add / Models / ViewModels / ResetPasswordVM (新密碼、 確認新密碼)
	[] add / MembersController . ResetPassword(int memberId, string confirmCode),add " ResetPassword " view page
	[] 寫 MembersController . ResetPassword(int memberId, string confirmCode,ResetPasswordVM model)
	[] add MemberService . ResetPassword(int memberId,string confirmCode,string newPassword)