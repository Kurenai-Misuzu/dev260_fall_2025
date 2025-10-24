using System;
using System.Collections.Generic;

namespace Assignment5
{
    /// <summary>
    /// Manages browser navigation state with back and forward stacks
    /// </summary>
    public class BrowserSession
    {
        private Stack<WebPage> backStack;
        private Stack<WebPage> forwardStack;
        private WebPage? currentPage;

        public WebPage? CurrentPage => currentPage;
        public int BackHistoryCount => backStack.Count;
        public int ForwardHistoryCount => forwardStack.Count;
        public bool CanGoBack => backStack.Count > 0;
        public bool CanGoForward => forwardStack.Count > 0;

        public BrowserSession()
        {
            backStack = new Stack<WebPage>();
            forwardStack = new Stack<WebPage>();
            currentPage = null;
        }

        /// <summary>
        /// Navigate to a new URL
        /// TODO: Implement this method
        /// - If there's a current page, push it to back stack
        /// - Clear the forward stack (new navigation invalidates forward history)
        /// - Set the new page as current
        /// </summary>
        public void VisitUrl(string url, string title)
        {
            // if current page isn't null
            if (currentPage != null)
            {
                // push current to backstack
                backStack.Push(currentPage);
            }
            // clear forward stack
            forwardStack.Clear();
            // set new page as current
            WebPage newPage = new WebPage(url, title);
            currentPage = newPage;
            // Console.WriteLine("WHAT IS THE CURRENT PAGE" + currentPage);

            //throw new NotImplementedException("VisitUrl method needs to be implemented");
        }

        /// <summary>
        /// Navigate back to previous page
        /// TODO: Implement this method
        /// - Check if back navigation is possible
        /// - Move current page to forward stack
        /// - Pop page from back stack and make it current
        /// </summary>
        public bool GoBack()
        {
            // backstack is possible (can go back)
            if (backStack.Count > 0 && currentPage != null)
            {
                // current page to forward stack
                forwardStack.Push(currentPage);
                // backstack to curernt page
                currentPage = backStack.Pop();
                return true;
            }
            // can't go back
            return false;
            //throw new NotImplementedException("GoBack method needs to be implemented");
        }

        /// <summary>
        /// Navigate forward to next page
        /// TODO: Implement this method
        /// - Check if forward navigation is possible
        /// - Move current page to back stack
        /// - Pop page from forward stack and make it current
        /// </summary>
        public bool GoForward()
        {
            // forwarding possible
            if (forwardStack.Count > 0 && currentPage != null)
            {
                // current to back
                backStack.Push(currentPage);
                // front stack to current
                currentPage = forwardStack.Pop();
                return true;
            }
            // can't go front
            return false;
            
            //throw new NotImplementedException("GoForward method needs to be implemented");
        }

        /// <summary>
        /// Get navigation status information
        /// </summary>
        public string GetNavigationStatus()
        {
            var status = $"📊 Navigation Status:\n";
            status += $"   Back History: {BackHistoryCount} pages\n";
            status += $"   Forward History: {ForwardHistoryCount} pages\n";
            status += $"   Can Go Back: {(CanGoBack ? "✅ Yes" : "❌ No")}\n";
            status += $"   Can Go Forward: {(CanGoForward ? "✅ Yes" : "❌ No")}";
            return status;
        }

        /// <summary>
        /// Display back history (most recent first)
        
        /// Expected output format:
        /// 📚 Back History (most recent first):
        ///    1. Google Search (https://www.google.com)
        ///    2. GitHub Homepage (https://github.com)
        ///    3. Stack Overflow (https://stackoverflow.com)
        /// 
        /// If empty, show: "   (No back history)"
        /// Use foreach to iterate through backStack (it gives LIFO order automatically)
        /// </summary>
        public void DisplayBackHistory()
        {

            // 1. Print header: "📚 Back History (most recent first):"
            // 2. Check if backStack.Count == 0, if so print "   (No back history)" and return
            // 3. Use foreach loop with backStack to display pages
            // 4. Show position number, page title, and URL for each page
            // 5. Format: "   {position}. {page.Title} ({page.Url})"

            // print header
            Console.WriteLine("📚 Back History (most recent first): ");
            // backstack empty
            if (backStack.Count < 1)
            {
                Console.WriteLine("   (No back history)");
                return;
            }
            // not emptyu
            int counter = 1;
            // enumerate through stack
            foreach (WebPage i in backStack)
            {
                Console.WriteLine($"{counter}. {i.Title} ({i.Url})");
                counter++;
            }

            //throw new NotImplementedException("DisplayBackHistory method needs to be implemented");
        }

        /// <summary>
        /// Display forward history (next page first)
        /// Expected output format:
        /// 📖 Forward History (next page first):
        ///    1. Documentation Page (https://docs.microsoft.com)
        ///    2. YouTube (https://www.youtube.com)
        /// 
        /// If empty, show: "   (No forward history)"
        /// Use foreach to iterate through forwardStack (it gives LIFO order automatically)
        /// </summary>
        public void DisplayForwardHistory()
        {
            // 1. Print header: "📖 Forward History (next page first):"
            // 2. Check if forwardStack.Count == 0, if so print "   (No forward history)" and return
            // 3. Use foreach loop with forwardStack to display pages
            // 4. Show position number, page title, and URL for each page
            // 5. Format: "   {position}. {page.Title} ({page.Url})"

            // forward stack emptu
            if (forwardStack.Count < 1)
            {
                Console.WriteLine("   (No forward history)");
                return;
            }
            // not empty
            int counter = 1;
            // enumerate through stack
            foreach (WebPage i in forwardStack)
            {
                Console.WriteLine($"{counter}. {i.Title} ({i.Url})");
                counter++;
            }

            //throw new NotImplementedException("DisplayForwardHistory method needs to be implemented");
        }

        /// <summary>
        /// Clear all navigation history
        /// Expected behavior:
        /// - Count total pages to be cleared (backStack.Count + forwardStack.Count)
        /// - Clear both backStack and forwardStack
        /// - Print confirmation: "✅ Cleared {totalCleared} pages from navigation history."
        /// Note: This does NOT clear the current page, only the navigation history
        /// </summary>
        public void ClearHistory()
        {
            // 1. Calculate total pages: int totalCleared = backStack.Count + forwardStack.Count;
            // 2. Clear both stacks: backStack.Clear() and forwardStack.Clear()
            // 3. Print confirmation message with count of cleared pages

            // calculate total pages
            int totalPages = backStack.Count + forwardStack.Count;
            // clear both
            backStack.Clear();
            forwardStack.Clear();
            // print confirmation
            Console.WriteLine($"✅ Cleared {totalPages} pages from navigation history.");

            //throw new NotImplementedException("ClearHistory method needs to be implemented");
        }
    }
}