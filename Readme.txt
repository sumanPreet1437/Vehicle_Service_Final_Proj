1. Open the Solution in Visual Studio
2. Build the project 
3. Navigate to tools ans select Nuget Package manager -> Package Manager Console (PMC)
4. On the console execute the following command
Update-Database identity -Context Vehicle_Service_IdentityDB



5. On the console execute the following command

  Update-Database Vehicle -Context Vehicle_Service_DataContext



6. After migration is successful Run the project 

7 if you login as admin  from the following credentials will be able to see the Vehicle Owners,  
Service Bookings and Services  Only admin can Add delete and update services and vehicle owners

User : admin@service.com
Password: 1qaz2wsX@

8. Also you can login with the following credentials to visit the site as a Vehicle owner
 and Can View and book services

 User : hans@service.com
Password: 1qaz2wsX@



9 if you need to create another  admin login with the admin credentials on step 7 above and
Click in "Add New Vehicle Admin" register a new admin 

10. You can sign up as a owner with Vehicle owner sign up link



The identity  authentication code used in the project were obtained by following URLS

Introduction to Identity on ASP.NET Core
https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-3.0&tabs=visual-studio
