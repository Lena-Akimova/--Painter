using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Painter_cur.Models
{
    [Table("Clients")]
    public class Client
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("c_code")]
        public int c_code { get; set; }

        [Required(ErrorMessage = "Укажите имя!")]
        [DisplayName("Имя")]
        [Column("c_firstn")]
        public string c_firstn { get; set; }

        [DisplayName("Фамилия")]
        [Column("c_secondn")]
        public string c_secondn { get; set; }

        [DisplayName("Отчество")]
        [Column("c_middlen")]
        public string c_middlen { get; set; }

        [Required(ErrorMessage = "Укажите адрес!")]
        [DisplayName("Адрес")]
        [Column("c_adress")]
        public string c_adress { get; set; }

        [Required(ErrorMessage = "Укажите эл. почту!")]
        [DisplayName("Эл. почта")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Такой эл. почты нет")]
        [DataType(DataType.EmailAddress)]
        [Column("c_email")]
        public string c_email { get; set; }

        [Required(ErrorMessage = "Укажите логин!")]
        [DisplayName("Логин")]
        [Column("c_login")]
        public string c_login { get; set; }

        [Required(ErrorMessage = "Укажите пароль!")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Пароль должен быть не менее 6 символов")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*?[#?!@$%^&*-]).{6,50}$",
            ErrorMessage = "Пароль должен содержать буквы верхнего и нижнего регистра, цифры и символы #?!@$%^&*-")]
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        [Column("c_password")]
        public string c_password { get; set; }

        [Column("c_role")]
        public string c_role { get; set; }


    }

    public class ClientRepository : IRepository<Client>
    {
        private List<Client> cach;
        private PainterContext _cont;

        public ClientRepository(PainterContext _context)
        {
            if (_context == null)
            {
                this.cach = null;
            }
            else
            {
                _cont = _context;
                ReLoad();
            }
        }

        public void ReLoad()
        {
            _cont.Clients.Load();
            this.cach = _cont.Clients.Local.ToList();
        }

        public void Save()
        {
            _cont.SaveChanges();
        }

        public void Create(Client cl)
        {
            if (_cont == null) return;
            _cont.Clients.Add(cl);
            Save();
        }



        public void Update(Client client)
        {
            if (_cont == null) return;
            var UpdEnt = _cont.Clients.FirstOrDefault(x => x.c_code == client.c_code);
            UpdEnt.c_firstn =client.c_firstn;
            UpdEnt.c_secondn = client.c_secondn;
            UpdEnt.c_middlen = client.c_middlen;
            UpdEnt.c_adress= client.c_adress;
            UpdEnt.c_password = client.c_password;
            Save();
        }


        public void Delete(int id)
        {
            if (_cont == null) return;
            var EntDel = _cont.Clients.FirstOrDefault(x => x.c_code == id);
            //уд клбаск
            _cont.Clients.Remove(EntDel);
            Save();
        }

        public Client Get(int id)
        {
            if (cach == null) { return null; }
            Client c= cach.Where(i => i.c_code == id).FirstOrDefault();
            return c;
        }

        public Client Get(string login, string pass)
        {
            if (cach == null) { return null; }

            return cach.Where(i => i.c_password==pass && i.c_login==login).FirstOrDefault();
        }

        public Client Get(string login)
        {
            if (cach == null) { return null; }

            return cach.Where(i =>  i.c_login == login).FirstOrDefault();
        }

        public List<Client> GetList()
        {
            return cach;
        }



        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }


public class LogOnModel
    {
        [Required]
        public string UserLogin { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    } 
}
