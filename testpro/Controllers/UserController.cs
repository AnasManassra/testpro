using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testpro.models;
using testpro.Repositories;
namespace testpro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserRepo  userRepo = null;
        private readonly IMapper _mapper;
        public List<UserViewModel> test;
        /*private readonly AppDbContext _dbcontext;
        public UserController(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        IUser U = null;
         public UserController(IUser U)
        {
            this.U = U;
        }
        */
        public UserController(IUserRepo userRepo, IMapper mapper)
        {
            this.userRepo = userRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public List<UserViewModel> Get()
        {
           List<UserViewModel> UVML = _mapper.Map<List<User>, List<UserViewModel>>(userRepo.get());
            
            return UVML;
            //return  _mapper.Map<UserViewModel>(temp);
           /* _dbcontext.Users.ToList();
           // _dbcontext.Users.Add(entity: new User(Id: 10) { name = "Test" });
            _dbcontext.SaveChanges();
            return _dbcontext.Users.ToList(); */
        }

        [HttpGet("{id}")]
        public UserViewModel Get(int id)
        {
            UserViewModel UVM = _mapper.Map<UserViewModel>(userRepo.get(id));
            return UVM ;
        }

       /* [HttpGet("{Names}")]
        public List<string> Get(string Names)
        {
            var b = Users.Select(item => item.name).ToList();
            return b;
        } //not working */

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            /* var deluser = _dbcontext.Users.SingleOrDefault(item => item.Id == id);
             if (deluser != null)
             {
                 _dbcontext.Users.Remove(deluser);
                 _dbcontext.SaveChanges();
            */
            userRepo.delete(id);
            }
        
        
       /* [HttpPut("{id}")]
        public void put(int id, [FromBody]User user)
        {
            var b = U.get(id);
            b.DoB = user.DoB;
            b.email = user.email;
            b.Id = user.Id;
            b.name = user.name;
            b.phone = user.phone;
            
        }
        */
        [HttpPost]
        public void post([FromBody]User user)
        {
            userRepo.add(user);
        }

    }
}
