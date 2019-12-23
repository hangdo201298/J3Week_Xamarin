using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace J3Week.Models
{
    public class FormsUser: IMultiSelectModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ImageSource ProfilePicture { get; set; }

        public string Name
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
