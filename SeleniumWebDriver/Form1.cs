using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWebDriver.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeleniumWebDriver
{
    public partial class Form1 : BaseForm
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            driver.Url = "https://aof.anadolu.edu.tr/anasayfa/Default.aspx";
            
            var element = driver.FindElement(By.Id("liOgrenci"));
            element.FindElement(By.TagName("a")).Click();
            driver.FindElement(By.Id("txtAccount")).SendKeys("tc no");
            driver.FindElement(By.Id("txtPassword")).SendKeys("şifre");
            driver.FindElement(By.Id("doButton")).Click();
            driver.Url = "https://aof.anadolu.edu.tr/ogrenci/DersDurum.aspx";
            var table = driver.FindElements(By.ClassName("DTableSutun")).Where(x=>x.GetAttribute("id").Contains("pnlAciklama"));
            string message=string.Empty ;
            foreach (var durumItem in table.GroupBy(x=>x.Text).Select(x=>x.Key))
            {
                message+= $"{durumItem}: {GetDersCount(table, durumItem)}\n";
            }

            MessageBox.Show( message, "Ders Durum");
        }
        public int GetDersCount(IEnumerable<IWebElement> table,string whereClouse)
        {
            return table.Where(x => x.Text == whereClouse).Count();
        }
        public void Sahininden()
        {
            driver.Url = "https://secure.sahibinden.com/giris";
            driver.FindElement(By.Id("username")).SendKeys("aliihsanakay");
            driver.FindElement(By.Id("password")).SendKeys(".");
            driver.FindElement(By.ClassName("show-hide-trigger")).Click();
            driver.FindElement(By.Id("userLoginSubmitButton")).Click();

            var loginControl = driver.FindElements(By.ClassName("error"));
            if (loginControl.Any())
            {
                MessageBox.Show(loginControl.FirstOrDefault().Text, "Hata");
            }
            else//login olduk demek
            {

            }

        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            QuitSeleniumDriver();
        }

       
    }
}
