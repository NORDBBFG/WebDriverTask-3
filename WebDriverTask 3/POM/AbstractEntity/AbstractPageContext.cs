namespace WebDriverTask_3.POM.AbstractEntity
{
    abstract class AbstractPageContext : AbstractPage
    {
        public T VerifyPageTitle<T>(string expectedTitle) where T : class
        {
            string actualTitle = driver.Title;
            Assert.That(actualTitle, Is.EqualTo(expectedTitle));
            try
            {
                return Activator.CreateInstance(typeof(T), driver) as T;
            }
            catch (Exception ex)
            {
                throw new Exception($"Something hepend with returning class! \n Exeption: {ex}");
            }
        }

        public T ClosePageByHandle<T>(string pageHandle) where T : class
        {
            driver.SwitchTo().Window(pageHandle);
            driver.Close();
            try
            {
                return Activator.CreateInstance(typeof(T), driver) as T;
            }
            catch (Exception ex)
            {
                throw new Exception($"Something hepend with returning class! \n Exeption: {ex}");
            }
        }

        public T SwitchPagebyHandle<T>(string pageHandle) where T : class
        {
            driver.SwitchTo().Window(pageHandle);
            try
            {
                return Activator.CreateInstance(typeof(T), driver) as T;
            }
            catch (Exception ex)
            {
                throw new Exception($"Something hepend with returning class! \n Exeption: {ex}");
            }
        }
    }
}
