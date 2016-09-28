using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FormsDemo
{
	public class PageItem
	{
		public string Title { get; set; }

		public string IconSource { get; set; }

		public Type TargetType { get; set; }

		public static IList<PageItem> All { set; get; }
		static PageItem()
		{
			All = new ObservableCollection<PageItem> 
			{
				new PageItem
				{
					Title = "Contacts",
					IconSource = "contacts.png",
					TargetType = typeof(ContactsPage)
				},
				new PageItem
				{
					Title = "TodoList",
					IconSource = "todo.png",
					TargetType = typeof(TodoListPage)
				}
			};
		}
	}
}
