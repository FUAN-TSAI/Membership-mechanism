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

[working on]會員按下email裡的確認連結 , MembersController.ConfirmRegister(), Service.ActiveRegister()

[working on] modify IMemberRepository  add Load(), ActiveRegister()
[working on] modify MemberRepository  add Load(), ActiveRegister()
[working on] modify MemberService . ActiveRegister





[]發信還沒寫
[]password 要編碼

[] implement RegisterCommamd.Execute()
[] implement MemberService.CreateNewMember()
[] add SendEmail Utility (at / Models / Infrastructures / EmailHelper.cs)