using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTest
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public ContactHelper CreateContactWholeProcess(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones
            };
        }

        public string GetContactInformationIndividualView(int index)
        {
            manager.Navigator.OpenHomePage();
            ViewContact(index);

            string contactDetails = driver.FindElement(By.Id("content")).Text + "\r\n";
            return contactDetails;
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            EditContact(index);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public ContactHelper EditContactWholeProcess(int index, ContactData contact)
        {
            EditContact(index);
            FillContactForm(contact);
            UpdateContact();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper EditById(ContactData originalContact, ContactData contact)
        {
            EditContact(originalContact.Id);
            FillContactForm(contact);
            UpdateContact();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.XPath("//tr[@name = 'entry']")).Count;
        }

        public ContactHelper RemoveContactWholeProcess(int index)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(index);
            RemoveContact();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper RemoveById(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(contact.Id);
            RemoveContact();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name = 'entry']"));
                foreach (IWebElement element in elements)
                {
                    
                    IWebElement lastName = element.FindElement(By.XPath("./td[2]"));
                    IWebElement firstName = element.FindElement(By.XPath("./td[3]"));

                    contactCache.Add(new ContactData(firstName.Text, lastName.Text){
                        Id = element.FindElement(By.Name("selected[]")).GetAttribute("value")
                    });
                }
            }

            return new List<ContactData>(contactCache);
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("mobile"), contact.MobilePhone);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value = 'Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public ContactHelper EditContact(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index+1) + "]")).Click();
            return this;
        }

        public ContactHelper EditContact(string id)
        {
            driver.FindElement(By.XPath("//a[contains(@href,'edit.php?id="+id+"')]/img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper ViewContact(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Details'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public bool IsContactExist()
        {
            return IsElementPresent(By.Name("selected[]"));
        }

        public ContactHelper UpdateContact()
        {
            driver.FindElement(By.XPath("//input[@value = 'Update']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper CheckExistingCreateIfNot()
        {
            if (!IsContactExist())
            {
                ContactData contactNew = new ContactData("pre-created", "pre-created");
                CreateContactWholeProcess(contactNew);
            }
            return this;
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.OpenHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupFromList(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => driver.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public GroupData AddContactToGroupIfNotExist(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            ClearGroupFilter();
            GroupData firstExistingGroup = GroupData.GetAll()[2];
            SelectContact(contact.Id);
            SelectGroupFromList(firstExistingGroup.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => driver.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            manager.Navigator.OpenHomePage();
            return firstExistingGroup;
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupFromList(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public void RemoveFirstContactFromGroup(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            GroupData group = FindFirstGroupWithContacts(contact);
            FilterContactsByGroup(group.Name);
            SelectFirstContact();
            CommitRemovingContact();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => driver.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void FilterContactsByGroup(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        public void CommitRemovingContact()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        public void SelectFirstContact()
        {
            driver.FindElement(By.XPath("(//input[@name= 'selected[]'])[1]")).Click();
        }

        public GroupData FindFirstGroupWithContacts(ContactData contact)
        {
            ClearGroupFilter();

            for (int i = 0; i < GroupData.GetAll().Count(); i++)
            {
                GroupData groupExisting = GroupData.GetAll()[i];
                List<ContactData> availableContacts = groupExisting.GetContacts();
                if (availableContacts.Count > 0)
                {
                    return  groupExisting;
                }
            }
            GroupData groupExisiting = AddContactToGroupIfNotExist(contact);
            return groupExisiting;
        }
    }
}
