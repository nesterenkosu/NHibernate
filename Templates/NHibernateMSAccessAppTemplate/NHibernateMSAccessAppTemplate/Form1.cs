using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernateMSAccessAppTemplate.Entities;

namespace NHibernateMSAccessAppTemplate
{
    public partial class Form1 : Form
    {
        ISession session;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Инициализация библиотеки NHibernate
            var c = new Configuration();
            c.Configure();
            c.AddAssembly("NHibernateMSAccessAppTemplate");

            //Для выполнения действий над данными
            //нужно открыть сессию
            session = c.BuildSessionFactory().OpenSession();

            //Получение данных из базы и отображение их в табличной части
            userBindingSource.DataSource = session.QueryOver<User>().List<User>();
        }
    }
}
