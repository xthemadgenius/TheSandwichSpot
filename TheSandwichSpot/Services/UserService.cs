using System.Threading.Tasks;
using System.Linq;
using TheSandwichSpot.Models;
using Firebase.Database;
using Firebase.Database.Query;
namespace TheSandwichSpot.Services
{
    public class UserService
    {
        FirebaseClient client;

        public UserService()
        {
            client = new FirebaseClient("https://thesandwichspot-94e39.firebaseio.com/");
        }
        public async Task<bool> IsUserExist(string uname)
        {
            var user = (await client.Child("Users")
                .OnceAsync<User>()).Where(u => u.Object.Username == uname).FirstOrDefault();

            return (user != null);
        }

        public async Task<bool> RegisterUser(string uname, string password)
        {
            if(await IsUserExist(uname) == false)
            {
                await client.Child("Users")
                    .PostAsync(new User()
                    {
                        Username = uname,
                        Password = password
                    });
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> LoginUser(string uname, string password)
        {
            var user = (await client.Child("Users")
                .OnceAsync<User>()).Where(u => u.Object.Username == uname)
                .Where(u => u.Object.Password == password).FirstOrDefault();
            return (user != null);
        }
    }
}
