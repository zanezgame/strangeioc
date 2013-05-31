/// LoadSceneCommand
/// ============================
/// This Command adds a Scene to the current one

using System;
using UnityEngine;
using babel.extensions.context.api;
using babel.extensions.command.impl;
using babel.extensions.dispatcher.eventdispatcher.impl;

namespace babel.examples.multiplecontexts.social
{
	public class LoadSceneCommand : EventCommand
	{
		
		public override void Execute()
		{
			string filepath = evt.data as string;
			
			//Load the component
			if (String.IsNullOrEmpty(filepath))
			{
				throw new Exception("Can't load a module with a null or empty filepath.");
			}
			Application.LoadLevelAdditive(filepath);
		}
	}
}

