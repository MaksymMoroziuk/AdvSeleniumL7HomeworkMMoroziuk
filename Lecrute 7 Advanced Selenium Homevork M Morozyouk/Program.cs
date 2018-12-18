using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lecrute_7_Advanced_Selenium_Homevork_M_Morozyouk
{
    class Program
    {

        static void Main(string[] args)
        {
            

            var driver = new ChromeDriver();

            
            /* Go to http://www.leafground.com/home.html */

            driver.Navigate().GoToUrl($"http://www.leafground.com/home.html");

            /*Open “HyperLink” page in new tab*/

            new Actions(driver).KeyDown(Keys.Control).Click(driver.FindElement(By.XPath("//*[text()='HyperLink']"))).KeyUp(Keys.Control).Perform();

            /* Hover on “Go to Home Page” link */

            driver.SwitchTo().Window(driver.WindowHandles[1]);
            new Actions(driver).MoveToElement(driver.FindElement(By.LinkText("Go to Home Page"))).Perform();

            /*Take a screenshot and save it somewhere*/

            var screenshot = driver.GetScreenshot();
            var destinationPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var screenshotPath = Path.Combine(destinationPath, "screenshot.png");
            screenshot.SaveAsFile(screenshotPath);

            /* Close the tab */

            driver.Close();

            /* Switch to first tab */

            driver.SwitchTo().Window(driver.WindowHandles[0]);

            /* Go to https://jqueryui.com/demos/ */

            driver.Navigate().GoToUrl($"https://jqueryui.com/demos/");

            /* Navigate to “Droppable” demo (Interactions section) */

            driver.FindElement(By.LinkText("Droppable")).Click();


            /*Switch to frame*/

            driver.SwitchTo().Frame(0);


            /* Drag &amp; Drop the small box into a big one */



            driver.FindElement(By.Id("draggable"));
            driver.FindElement(By.Id("droppable"));

            var dropTargetElement = driver.FindElement(By.Id("droppable"));
            var draggableElement = driver.FindElement(By.Id("draggable"));

            var actions = new Actions(driver);

            actions.DragAndDrop(draggableElement, dropTargetElement).Perform();
            Assert.AreEqual("Dropped!", dropTargetElement.Text);

            driver.Close();

        }
    }
 }

