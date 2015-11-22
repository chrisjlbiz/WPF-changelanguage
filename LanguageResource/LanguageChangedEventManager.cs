﻿using System;
using System.Windows;

namespace LanguageResource
{
    class LanguageChangedEventManager : WeakEventManager
    {
        static readonly object padlock = new object { };

        static LanguageChangedEventManager Instance
        {
            get
            {
                lock (padlock)
                {
                    var instance = (LanguageChangedEventManager)GetCurrentManager(typeof(LanguageChangedEventManager));

                    if (instance == null)
                    {
                        instance = new LanguageChangedEventManager { };
                        SetCurrentManager(typeof(LanguageChangedEventManager), instance);
                    }
                    return instance;
                }
            }
        }

        LanguageChangedEventManager() { }
        
        /// <summary>
        /// Adds the provided listener to the provided publisher for the event being managed.
        /// </summary>
        public static void AddListener(LanguageChangedEventPublisher publisher, IWeakEventListener listener)
        {
            Instance.ProtectedAddListener(publisher, listener);
        }

        /// <summary>
        /// Removes a previously added listener from the provided publisher.
        /// </summary>
        public static void RemoveListener(LanguageChangedEventPublisher publisher, IWeakEventListener listener)
        {
            Instance.ProtectedRemoveListener(publisher, listener);
        }

        // Hooks the provided publisher event with the DeliverEvent method.
        protected override void StartListening(object source)
        {
            var publisher = (LanguageChangedEventPublisher)source;
            publisher.LanguageChanged += this.DeliverEvent;
        }

        // Unhooks the provided publisher event from the DeliverEvent method.
        protected override void StopListening(object source)
        {
            var publisher = (LanguageChangedEventPublisher)source;
            publisher.LanguageChanged -= this.DeliverEvent;
        }
    }

    class LanguageChangedEventPublisher
    {
        static readonly LanguageChangedEventPublisher _instance = new LanguageChangedEventPublisher { };

        public static LanguageChangedEventPublisher Instance { get { return _instance; } }

        LanguageChangedEventPublisher() { }

        public event EventHandler LanguageChanged;

        /// <summary>
        /// Invokes the language changed event.
        /// </summary>
        public void OnLanguageChanged()
        {
            var languageEvent = LanguageChanged;

            if (languageEvent != null)
                languageEvent(this, EventArgs.Empty);
        }
    }
}
