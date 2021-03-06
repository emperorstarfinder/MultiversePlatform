/********************************************************************

The Multiverse Platform is made available under the MIT License.

Copyright (c) 2012 The Multiverse Foundation

Permission is hereby granted, free of charge, to any person 
obtaining a copy of this software and associated documentation 
files (the "Software"), to deal in the Software without restriction, 
including without limitation the rights to use, copy, modify, 
merge, publish, distribute, sublicense, and/or sell copies 
of the Software, and to permit persons to whom the Software 
is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be 
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE 
OR OTHER DEALINGS IN THE SOFTWARE.

*********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.MultiverseInterfaceStudio.FrameXml.Serialization;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Microsoft.MultiverseInterfaceStudio.FrameXml.Controls
{
	[ToolboxBitmap(typeof(System.Windows.Forms.CheckBox), "CheckBox.bmp")]
    [ToolboxItemFilter("MultiverseInterfaceStudioFilter", ToolboxItemFilterType.Require)]
    public class CheckButton : GenericFrameControl<CheckButtonType>
	{
		public CheckButton() : base(CreateInnerControl())
		{
            this.TypedSerializationObject.inherits = "UICheckButtonTemplate";
		}

		private static Control CreateInnerControl()
		{
			CheckBox control = new CheckBox();
			control.BackColor = Color.DarkGray;
			control.ForeColor = Color.Gold;
			return
				control;
		}

		private CheckBox TypedInnerControl
		{
			get { return (CheckBox)InnerControl; }
		}

		private static string[] inheritsList = new string[] {
			"UICheckButtonTemplate",
			"UIRadioButtonTemplate",
		};

		public override List<string> InheritsList
		{
			get
			{
				var result = base.InheritsList;
				result.AddRange(inheritsList);
				return result;
			}
		}

		protected override void OnUpdateControl()
		{
			base.OnUpdateControl();

			InnerControl.Text = TypedSerializationObject.text;
			TypedInnerControl.Checked = TypedSerializationObject.@checked;
		}

		public override void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnPropertyChanged(e);

			switch (e.PropertyName)
			{
				case "text":
					InnerControl.Text = TypedSerializationObject.text;
					break;
				case "checked":
					TypedInnerControl.Checked = TypedSerializationObject.@checked;
					break;
			}
		}

		public override EventChoice? DefaultEventChoice
		{
			get
			{
				return EventChoice.OnClick;
			}
		}
	}
}
