using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyFirstApp.Models;

namespace MyFirstApp.CustomModelBinders
{
    public class PersonModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            Person person = new Person();

            //FirstName and LastName
            if (bindingContext.ValueProvider.GetValue("FirstName").Length > 0)
            {
                person.PersonName = bindingContext.ValueProvider.GetValue("FirstName").FirstValue;

                if (bindingContext.ValueProvider.GetValue("LastName").Length > 0)
                {
                    person.PersonName += " " + bindingContext.ValueProvider.GetValue("LastName").FirstValue;
                }
            }

            //Email
            if (bindingContext.ValueProvider.GetValue("Email").Length > 0)
                person.Email = bindingContext.ValueProvider.GetValue("Email").FirstValue;

            //Phone
            if (bindingContext.ValueProvider.GetValue("PhoneNumber").Length > 0)
                person.PhoneNumber = bindingContext.ValueProvider.GetValue("PhoneNumber").FirstValue;

            //Password
            if (bindingContext.ValueProvider.GetValue("Password").Length > 0)
                person.Password = bindingContext.ValueProvider.GetValue("Password").FirstValue;

            //ConfirmPassword
            if (bindingContext.ValueProvider.GetValue("ConfirmPassword").Length > 0)
                person.ConfirmPassword = bindingContext.ValueProvider.GetValue("ConfirmPassword").FirstValue;

            //Price
            if (bindingContext.ValueProvider.GetValue("Salary").Length > 0)
                person.Salary = Convert.ToDouble(bindingContext.ValueProvider.GetValue("Salary").FirstValue);

            //DateOfBirth
            if (bindingContext.ValueProvider.GetValue("DateOfBirth").Length > 0)
                person.DateOfBirth = Convert.ToDateTime(bindingContext.ValueProvider.GetValue("DateOfBirth").FirstValue);



            bindingContext.Result = ModelBindingResult.Success(person);
            return Task.CompletedTask;
        }
    }
}