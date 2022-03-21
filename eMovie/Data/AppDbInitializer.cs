using eMovie.Data.Static;
using eMovie.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMovie.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Cinemas Data
                if(!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "PVR Cinemas",
                            Logo = "https://th.bing.com/th/id/R.8b786417eb45f9cd9b14eb8ba31f2d8a?rik=1nu0WKaddurM7w&riu=http%3a%2f%2f3.bp.blogspot.com%2f-ZLrwUn6wQFE%2fU6gACKkAEDI%2fAAAAAAAACNc%2fD1giljK9U2Y%2fs1600%2fPVR%2bCINEMAS.png&ehk=y%2bg19sBN9JkeUwd6oiyeFYkse%2bxzjeYffqaR3qGwR2U%3d&risl=&pid=ImgRaw&r=0",
                            Description = "PVR Cinemas is a movie theater chain in India with its headquarter located in Gurgaon."
                        },
                        new Cinema()
                        {
                            Name = "Carnival Cinema",
                            Logo = "https://th.bing.com/th/id/OIP.bhXqORu8zbXN7FojLTHk1QHaEW?w=248&h=180&c=7&r=0&o=5&dpr=1.5&pid=1.7",
                            Description = "Carnival Cinemas is a multiplex chain in India in 120 cities at 162 locations"
                        },
                        new Cinema()
                        {
                            Name = "INOX Cinema",
                            Logo = "https://th.bing.com/th/id/OIP.H7SboYB1KP-cpX3zwFirHwHaCt?w=321&h=127&c=7&r=0&o=5&dpr=1.5&pid=1.7",
                            Description = "INOX Leisure or INOX Movies is an Indian movie theater chain."
                        },
                        new Cinema()
                        {
                            Name = "Cinepolis",
                            Logo = "https://th.bing.com/th/id/OIP.GsRzrOlDxHcR-ooMaHkfmgHaB0?w=308&h=86&c=7&r=0&o=5&dpr=1.5&pid=1.7",
                            Description = "Cinépolis is a Mexican movie theater chain. Its name means City of Cinema and its slogan is La Capital del Cine."
                        },
                        new Cinema()
                        {
                            Name = "PVR Director's Cut",
                            Logo = "https://th.bing.com/th/id/OIP._aCBF2iMzZErOyIZ2Mc25AHaHa?w=162&h=180&c=7&r=0&o=5&dpr=1.5&pid=1.7",
                            Description = "PVR's Director's Cut®, the luxury arm of PVR Cinemas, blends the best in high-end hospitality and entertainment."
                        },
                    });
                    context.SaveChanges();
                }
                //Actors Data
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Shah Rukh Khan",
                            Bio = "Shah Rukh Khan is a 54 year old Indian Actor. Born on 2nd November, 1965 in New Delhi, India, he is famous for Hindi films.",
                            ProfilePicURL = "https://th.bing.com/th/id/OIP.g9cnahgPDy4E5pwZ6j6QpwHaEK?w=313&h=180&c=7&r=0&o=5&dpr=1.5&pid=1.7"

                        },
                        new Actor()
                        {
                            FullName = "Akshay Kumar",
                            Bio = "Rajiv Hari Om Bhatia, known professionally as Akshay Kumar, is an Indian-born naturalised Canadian actor, film producer, martial artist and television personality who works in Bollywood,",
                            ProfilePicURL = "https://th.bing.com/th/id/OIP.Yi3ZlAM8uJeeA6EqwxWFugHaD5?w=309&h=180&c=7&r=0&o=5&dpr=1.5&pid=1.7"
                        },
                        new Actor()
                        {
                            FullName = "Salman Khan",
                            Bio = "Salman khan is an Indian film actor, producer, and television personality.",
                            ProfilePicURL = "https://th.bing.com/th/id/OIP.ontrYUByRm-LiSJUxgn7gAHaFj?w=225&h=180&c=7&r=0&o=5&dpr=1.5&pid=1.7"
                        },
                        new Actor()
                        {
                            FullName = "Ranveer Singh",
                            Bio = "Ranveer Singh Bhavnani is an Indian actor who is known for his work in Hindi films. The recipient of several awards, including four Filmfare Awards, he is among the highest-paid Indian actors ",
                            ProfilePicURL = "https://th.bing.com/th/id/OIP.a5yVIeeoiroOl-hCr0RH5wHaE8?w=239&h=180&c=7&r=0&o=5&dpr=1.5&pid=1.7"
                        },
                        new Actor()
                        {
                            FullName = "Ajay Devgn",
                            Bio = "Vishal Veeru Devgan (born 2 April 1969), known professionally as Ajay Devgn, is an Indian actor, film director and producer. He has appeared in over a hundred Hindi films.",
                            ProfilePicURL = "https://th.bing.com/th/id/OIP.nlijq3QO9TtO0-PCFtru7QHaFj?w=227&h=180&c=7&r=0&o=5&dpr=1.5&pid=1.7"
                        }
                    });
                    context.SaveChanges();
                }
                //Producers Data
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Rohit Shetty",
                            Bio = "This is the Bio of the first actor",
                            ProfilePicURL = "https://th.bing.com/th/id/OIP.B6r2jxbJxrD-a07_C8vpLAHaF7?w=231&h=185&c=7&r=0&o=5&dpr=1.5&pid=1.7"

                        },
                        new Producer()
                        {
                            FullName = "Sajid NadiadWala",
                            Bio = "Sajid Nadiadwala (born 18 February 1966) is an Indian film producer and director, and owner of Nadiadwala Grandson Entertainment.",
                            ProfilePicURL = "https://th.bing.com/th/id/OIP.3o0-p2_M6ajuAWhO6TxxwwHaFj?w=237&h=180&c=7&r=0&o=5&dpr=1.5&pid=1.7"
                        },
                        new Producer()
                        {
                            FullName = "Gauri Khan",
                            Bio = "Gauri Khan (née Chibber; born 8 October 1970) is an Indian film producer and designer",
                            ProfilePicURL = "https://th.bing.com/th/id/OIP.IvdG2quql-LwBccHvd2TXAHaEo?w=310&h=193&c=7&r=0&o=5&dpr=1.5&pid=1.7"
                        },
                        new Producer()
                        {
                            FullName = "Sohail khan",
                            Bio = "Sohail Salim Abdul Rashid Khan (born 20 December 1970) is an Indian actor, writer, film director and producer",
                            ProfilePicURL = "https://th.bing.com/th/id/OIP.lK9ZlnzMvWsMw_b4ZD2kmQHaEZ?w=314&h=186&c=7&r=0&o=5&dpr=1.5&pid=1.7"
                        },
                        new Producer()
                        {
                            FullName = "Kabir Khan",
                            Bio = "Kabir Khan is an Indian film director, screenwriter and cinematographer who works in Hindi cinema.",
                            ProfilePicURL = "https://th.bing.com/th/id/OIP.4C-AIn5Z5jJE1ej2WtZjTwHaEK?w=290&h=180&c=7&r=0&o=5&dpr=1.5&pid=1.7"
                        }
                    });
                    context.SaveChanges();
                }

                //Movies Data
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Sooryavanshi",
                            Description = "Mumbai’s Anti-Terrorism Squad chief DCP Veer Sooryavanshi (Akshay Kumar) joins forces with Inspector Simmba Bhalerao (Ranveer Singh) and DCP Bajirao Singham (Ajay Devgn) in an attempt to foil the plans of a terrorist group to launch a deadly attack on Mumbai.",
                            Price = 39.50,
                            ImageURL = "https://th.bing.com/th/id/OIP.DYgK21msNa6kPBzHYFCJZQHaHX?w=152&h=180&c=7&r=0&o=5&dpr=1.5&pid=1.7",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 2,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Simmba",
                            Description = "Simmba, a Corrupt Officer, enjoys all the perks of being an immoral and unethical police officer until a life-changing event forces him to choose the righteous path.",
                            Price = 29.50,
                            ImageURL = "https://th.bing.com/th/id/OIP.-uYtA3ng-0EtAgzQCHA7lAHaJ8?w=157&h=211&c=7&r=0&o=5&dpr=1.5&pid=1.7",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 3,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Radhe",
                            Description = "Radhe: Your Most Wanted Bhai is a 2021 Indian Hindi-language action thriller film directed by Prabhu Deva",
                            Price = 39.50,
                            ImageURL = "https://th.bing.com/th/id/OIP.F0ynrKWoAgDeuvLECuN_OgHaLh?w=115&h=180&c=7&r=0&o=5&dpr=1.5&pid=1.7",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Drama
                        },
                        new Movie()
                        {
                            Name = "Bacchan Pandey",
                            Description = "A budding director tries to research a merciless gangster for making a film on gangster-ism. ",
                            Price = 39.50,
                            ImageURL = "https://th.bing.com/th?id=OIF.Ko6AER4D1L%2fm4%2fcYCGL1XA&w=144&h=180&c=7&r=0&o=5&dpr=1.5&pid=1.7",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 4,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Zero",
                            Description = "The story revolves around Bauua Singh (Shah Rukh Khan), a vertically challenged man, who is full of charm and wit, with a pinch of arrogance.",
                            Price = 39.50,
                            ImageURL = "https://th.bing.com/th/id/OIP.dYQn6wYFg9hBxM9Bu6LqYgHaHa?w=145&h=180&c=7&r=0&o=5&dpr=1.5&pid=1.7",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 2,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Comedy
                        },
                        new Movie()
                        {
                            Name = "83",
                            Description = "On June 25, 1983, the Lord's Cricket Ground witnessed 14 men beat the two times World Champions West Indies, putting India back onto the cricket world stage.",
                            Price = 39.50,
                            ImageURL = "https://th.bing.com/th/id/OIP.FWsk7ofpjEH9jnagq2r5tgHaJQ?w=115&h=180&c=7&r=0&o=5&dpr=1.5&pid=1.7",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 2,
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Documentary
                        }
                    });
                    context.SaveChanges();
                }
                
                //Actors & Movies data
                if (!context.Actors_Movies.Any())
                 {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 2
                        },

                         new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                         new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },

                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 4
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 6
                        },


                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 7
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 7
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 7
                        },
                    });
                    context.SaveChanges();
                }
                //if (!context.Users.Any())
                //{
                //    context.Users.AddRange(new List<Login>()
                //    {
                //        new Login()
                //        {
                //            EmailAddress = "admin@emovie.com",
                //            Password = "admin123"
                //        },
                //        new Login()
                //        {
                //            EmailAddress = "user1@emovie.com",
                //            Password = "user1"
                //        },
                //    });
                //    context.SaveChanges();
                //}
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@emovie.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Admin@123");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@emovie.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "User@123");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            } 
        }
    }
}
