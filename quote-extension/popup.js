async function getRandomQuote() {
  const res = await fetch(chrome.runtime.getURL("quote.json"));
  const data = await res.json();

  const random = data[Math.floor(Math.random() * data.length)];

  // Update UI
  document.getElementById("quote").innerText = random.quote;
  document.getElementById("author").innerText = random.author;

  // Save to storage
  chrome.storage.local.set({
    quote: random.quote,
    author: random.author
  });
}

// Load stored quote on open
function loadQuote() {
  chrome.storage.local.get(["quote", "author"], (result) => {
    if (result.quote && result.author) {
      document.getElementById("quote").innerText = result.quote;
      document.getElementById("author").innerText = result.author;
    } else {
      getRandomQuote(); // fallback
    }
  });
}

// Attach event
document.getElementById("newQuoteBtn").addEventListener("click", getRandomQuote);
loadQuote();