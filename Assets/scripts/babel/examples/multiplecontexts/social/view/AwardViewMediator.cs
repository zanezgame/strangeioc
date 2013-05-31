/// Example mediator
/// =====================
/// Make your Mediator as thin as possible. Its function is to mediate
/// between view and app. Don't load it up with behavior that belongs in
/// the View (listening to/controlling interface), Commands (business logic),
/// Models (maintaining state) or Services (reaching out for data).

using System;
using UnityEngine;
using babel.extensions.dispatcher.eventdispatcher.impl;
using babel.extensions.mediation.impl;
using  babel.examples.multiplecontexts.game;

namespace babel.examples.multiplecontexts.social
{
	public class AwardViewMediator : MediatorWithDispatcher
	{
		private AwardView view;
		
		public override void onRegister()
		{
			view = abstractView as AwardView;
			
			//Listen to the global event bus for events
			dispatcher.addListener(GameEvent.RESTART_GAME, onGameRestart);
			dispatcher.addListener(SocialEvent.REWARD_TEXT, onReward);
			
			view.init ();
		}
		
		public override void onRemove()
		{
			//Clean up listeners when the view is about to be destroyed
			dispatcher.removeListener(GameEvent.RESTART_GAME, onGameRestart);
			dispatcher.removeListener(SocialEvent.REWARD_TEXT, onReward);
		}
		
		private void onGameRestart()
		{
			GameObject.Destroy(gameObject);
		}
		
		private void onReward(object payload)
		{
			TmEvent evt = payload as TmEvent;
			view.setTest(evt.data as string);
		}
	}
}

