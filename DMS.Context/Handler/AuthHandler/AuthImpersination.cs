using DC.DMS.Services.AuthHandler;
using DC.DMS.Services.Models.Auth;
using DMS.Context.Data;
using Microsoft.EntityFrameworkCore;
using static DC.DMS.Services.Enum.WorkflowEnums;

namespace DMS.ContextAuthHandler
{
    public class AuthImpersination : IUserHandling
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        IUtils Utils = new IronConversion();
        public AuthImpersination(IDbContextFactory<ApplicationDbContext> dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<(string Result, string Role, string User, int UserID)> AuthenticateUserAsync(string email, string password)
        {
            try
            {
                await using var db = await _dbContext.CreateDbContextAsync();
                string result = "";
                string role = "";
                string user = "";
                int userID = 0;
                System.Data.DataTable dt = new System.Data.DataTable();
                if (await EmailExistsAsync(email))
                {
                    dt = Utils.ToDataTable(db.ApplicationUsers.Where(x => x.Email.Equals(email)).ToList());
                    if (Convert.ToInt32(dt.Rows[0][0]) == 0)
                    {
                        result = "Your Account is locked by Admin.";
                        role = "";
                        user = "";
                        userID = 0;
                    }
                    else
                    {
                        var locked = db.ApplicationUsers.Where(x => x.Email.Equals(email)).ToList().Select(x => x.IsLocked).ToList();
                        if (Convert.ToInt32(locked[0].Value) == 1)
                        {
                            result = "Account has been locked by invalid credential attempt.";
                            role = "";
                            user = "";
                            userID = 0;
                        }
                        else
                        {
                            var count = (from x in db.ApplicationUsers where x.Email.Equals(email) && x.Password.Equals(password) select x).Count();
                            if (Convert.ToInt32(count) == 1)
                            {
                                db.ApplicationUsers.Where(x => x.Email.Equals(email)).ToList().ForEach(x => { x.RetryAttempts = 0; x.LastLogin = DateTime.Now; });
                                //db.SaveChanges();
                                result = "Logged Successfully!";
                                int i = Convert.ToInt32(dt.Rows[0][12].ToString());
                                role = db.Roles.FirstOrDefault(x => x.ID.Equals(i)).RoleName;
                                user = dt.Rows[0][1].ToString();
                                userID = Convert.ToInt32(dt.Rows[0][0]);
                            }
                            else
                            {
                                var retryCount = db.ApplicationUsers.Where(x => x.Email == email).Select(x => x.RetryAttempts).FirstOrDefault();
                                retryCount = retryCount + 1;
                                if (retryCount <= 3)
                                {
                                    db.ApplicationUsers.Where(x => x.Email.Equals(email)).ToList().ForEach(x => x.RetryAttempts = retryCount);
                                    db.SaveChanges();

                                    result = "Invalid Password, No of attemps " + retryCount + " out of 3.";
                                    role = "";
                                    user = "";
                                    userID = 0;
                                }
                                else
                                {
                                    db.ApplicationUsers.Where(x => x.Email.Equals(email)).ToList().ForEach(x =>
                                    {
                                        x.RetryAttempts = retryCount;
                                        x.IsLocked = true;
                                        x.LockedDateTime = DateTime.Now;
                                    });
                                    db.SaveChanges();
                                    //db.Update("UPDATE user SET RetryAttempts = '" + retryCount+"', IsLocked = 1, LockedDateTime = NOW(3) WHERE Email = '"+email+"';");
                                    result = "Your account is locked.";
                                    role = "";
                                    user = "";
                                    userID = 0;
                                }
                            }
                        }
                    }
                }
                else
                {
                    result = "Invalid email Id.";
                    role = "";
                    user = "";
                    userID = 0;
                }

                return (result, role, user, userID);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async Task<bool> EmailExistsAsync(string email)
        {
            await using var db = await _dbContext.CreateDbContextAsync();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = Utils.ToDataTable(db.ApplicationUsers.Where(x => x.Email.Equals(email)).Select(x => x.ID).ToList());
            //dt = db.Select("Select * from user where Email='" + email+"'");
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<string> ChangePasswordAsync(string email, string currentPassword, string newPassword, string confirmPassword)
        {
            try
            {
                await using var db = await _dbContext.CreateDbContextAsync();
                string result = "";
                if (newPassword == confirmPassword)
                {
                    var count = (from x in db.ApplicationUsers where x.Email.Equals(email) && x.Password.Equals(currentPassword) select x).Count();
                    //var count = db.SelectWithReturn("select  count(*) from user where Email = '" + email + "' and Password = '" + currentPassword + "';");
                    if (Convert.ToInt32(count) > 0)
                    {
                        db.ApplicationUsers.Where(x => x.Email.Equals(email)).ToList().ForEach(x => x.Password = newPassword);
                        db.SaveChanges();
                        //db.Update("update user set Password = '" + newPassword + "' where Email = '" + email + "';");
                        result = "Your Password changed successfully!";
                    }
                    else
                    {
                        result = "Your current password is invalid.";
                    }
                }
                else
                {
                    result = "New password and confirm password not matched.";
                }
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<string> CheckEmailAsync(string email, string action, string questionOut, string answerIn, string changePassword)
        {
            try
            {
                await using var db = await _dbContext.CreateDbContextAsync();
                string result = "";
                questionOut = "";
                if (action == "CheckEmail")
                {

                    if (await EmailExistsAsync(email))
                    {
                        result = "Please answer the security Question.";
                        questionOut = db.ApplicationUsers.Where(x => x.Email.Equals(email)).Select(x => x.Questions.question).FirstOrDefault();

                    }
                    else
                    {
                        result = "Your email not found.";
                    }
                }
                else if (action == "CheckSecurity")
                {
                    if (await EmailExistsAsync(email, answerIn))
                    {
                        result = "Enter new password!";
                    }
                    else
                    {
                        result = "Your answer is invalid.";
                    }
                }
                else if (action == "ChangePassword")
                {
                    db.ApplicationUsers.Where(x => x.Email.Equals(email)).ToList().ForEach(x => { x.Password = changePassword; x.IsLocked = false; x.RetryAttempts = 0; });
                    db.SaveChanges();
                    //db.Update(" UPDATE user SET password = '" + changePassword + "', isLocked = 0, RetryAttempts = 0 WHERE  email = '" + email + "'; ");
                    result = "Password changed successfully.";
                }
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async Task<bool> EmailExistsAsync(string email, string answerIn)
        {
            await using var db = await _dbContext.CreateDbContextAsync();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = Utils.ToDataTable(db.ApplicationUsers.Where(x => x.Email.Equals(email) && x.SecrateAnswer.Equals(answerIn)).ToList());
            //dt = db.Select("Select * from user where Email='" + email + "' and SecretAnswer = '" + answerIn + "';");
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public async void ReadUsers(string id, string userName, string email, string role, string isActivated)
        {
            userName = "";
            email = "";
            role = "";
            isActivated = "";
            System.Data.DataTable dt = new System.Data.DataTable();
            await using var db = await _dbContext.CreateDbContextAsync();
            dt = Utils.ToDataTable(db.ApplicationUsers.Where(x => x.ID.Equals(id)).ToList());
            userName = dt.Rows[0][0].ToString();
            email = dt.Rows[0][1].ToString();
            role = dt.Rows[0][2].ToString();
            isActivated = dt.Rows[0][3].ToString();
        }

        public async Task<string> RegisterAsync(string userName, string password, string email, string roleID, string question, string answer, DcsUsers flag)
        {
            string result = "";
            await using var db = await _dbContext.CreateDbContextAsync();
            if (await EmailExistsAsync(email))
            {
                result = "Email already exists.";
            }
            else
            {
                int i = Convert.ToInt32(question);
                User users = new User();
                users.UserName = userName;
                users.Password = password;
                users.Email = email;
                users.RoleID = Convert.ToInt32(roleID);
                users.CreatedDateTime = DateTime.Now;
                users.Questions = db.Questions.FirstOrDefault(x => x.ID.Equals(i));
                users.SecrateAnswer = answer;
                users.IsActivated = true;
                users.IsLocked = false;
                users.Flag = flag;
                db.ApplicationUsers.Add(users);
                var res = db.SaveChanges() == 1 ? true : false;
                if (res)
                {
                    result = "Successfully Registred.";
                }
            }
            return result;
        }

        public async Task<string> ManageUsersAsync(int Id, int role, bool isActive)
        {
            try
            {
                await using var db = await _dbContext.CreateDbContextAsync();
                string Result = "";
                var count = db.ApplicationUsers.Where(x => x.RoleID == 1 && x.IsActivated == true).Count();
                if (Convert.ToInt32(count) == 0)
                {
                    if (role == 1)
                    {
                        var countSelect = "";
                        if (Convert.ToInt32(countSelect) == 0)
                        {
                            Result = "One admin role account must exists.";
                        }
                        else
                        {
                            if (Convert.ToInt32(isActive) == 1)
                            {
                                db.ApplicationUsers.Where(x => x.ID.Equals(Id)).ToList().ForEach(x =>
                                {
                                    x.RoleID = role;
                                    x.DeactivatedDateTime = null;
                                    x.IsActivated = isActive;
                                    x.IsLocked = false;
                                });
                                db.SaveChanges();
                                Result = "Successfully updated.";
                            }
                            else
                            {
                                db.ApplicationUsers.Where(x => x.ID.Equals(Id)).ToList().ForEach(x =>
                                {
                                    x.RoleID = role;
                                    x.DeactivatedDateTime = DateTime.Now;
                                    x.IsActivated = isActive;
                                    x.IsLocked = false;
                                });
                                db.SaveChanges();
                                Result = "Successfully updated.";
                            }
                        }
                    }
                    else
                    {
                        Result = "One admin role account must exists.";
                    }
                }
                else
                {
                    if (Convert.ToInt32(isActive) == 1)
                    {
                        db.ApplicationUsers.Where(x => x.ID.Equals(Id)).ToList().ForEach(x =>
                        {
                            x.RoleID = role;
                            x.DeactivatedDateTime = null;
                            x.IsActivated = isActive;
                        });
                        db.SaveChanges();
                        //db.Update("update user set RoleID = '" + role + "', DeactivatedDateTime = NULL,  isActivated = b'" + Convert.ToInt32(isActive) + "'  where ID = '" + Id + "' ;");
                        Result = "Successfully updated.";
                    }
                    else
                    {
                        db.ApplicationUsers.Where(x => x.ID.Equals(Id)).ToList().ForEach(x =>
                        {
                            x.RoleID = role;
                            x.DeactivatedDateTime = DateTime.Now;
                            x.IsActivated = isActive;
                        });
                        db.SaveChanges();
                        //db.Update("update user set RoleID = '" + role + "', DeactivatedDateTime = NOW(3),  isActivated = b'" + Convert.ToInt32(isActive) + "'  where ID = '" + Id + "' ;");
                        Result = "Successfully updated.";
                    }
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<System.Data.DataTable> SearchViewUsersAsync(string search)
        {
            try
            {
                await using var db = await _dbContext.CreateDbContextAsync();
                //if (string.IsNullOrWhiteSpace(search)) search = AppUser.CurrentUserName;
                return Utils.ToDataTable(db.ApplicationUsers.Where(x => x.UserName.Contains(search)).ToList());
                //return Utils.ToDataTable((from a in db.users where a.UserName.Contains(search) select new User { ID = a.ID,UserName = a.UserName,Email = a.Email,RetryAttempts = a.RetryAttempts,IsActivated = a.IsActivated,IsLocked = a.IsLocked,DeactivatedDateTime = a.DeactivatedDateTime,LockedDateTime = a.LockedDateTime,CreatedDateTime = a.CreatedDateTime,LastLogin = a.LastLogin,Roles = a.Roles}).ToList());
                //return db.Select("SELECT  Users.ID, Users.UserName, Users.Email, Users.RetryAttampts, Users.isActivated, Users.isLocked, Users.DeactivatedDateTime, Users.LockedDateTime, Users.CreatedDateTime, Users.LastLogin, Roles.Name FROM  user Users INNER JOIN role Roles ON Users.RoleId = Roles.Id WHERE(Users.UserName like Concat('%', IFNULL('" + search + "', Users.UserName), '%')); ");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
