// Create alarm when extension installs
chrome.runtime.onInstalled.addListener(() => {
  chrome.alarms.create("randomQuoteAlarm", {
    periodInMinutes: 1
  });
});

// When alarm triggers
chrome.alarms.onAlarm.addListener(async (alarm) => {
  if (alarm.name === "randomQuoteAlarm") {
    const res = await fetch(chrome.runtime.getURL("quote.json"));
    const data = await res.json();

    // Get random quote
    const random = data[Math.floor(Math.random() * data.length)];

    // Save in storage
    chrome.storage.local.set({ quote: random.quote, author: random.author });

    console.log("New quote:", random.quote);
  }
});