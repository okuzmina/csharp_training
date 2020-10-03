using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebAddressbookTest
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public GroupHelper CreateGroupWholeProcess(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text));
                }
            }

            return new List<GroupData>(groupCache);
        }

        public GroupHelper EditGroupWholeProcess(int index, GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(index);
            EditGroup();
            FillGroupForm(group);
            UpdateGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper RemoveGroupWholeProcess(int index)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(index);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public bool IsGrouptExist()
        {
            return IsElementPresent(By.Name("selected[]"));
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper EditGroup()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper UpdateGroup()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper CheckExistngCreateIfNot()
        {
            if (!IsGrouptExist())
            {
                GroupData groupNew = new GroupData("pre-created");
                CreateGroupWholeProcess(groupNew);
            }
            return this;
        }
    }
}
