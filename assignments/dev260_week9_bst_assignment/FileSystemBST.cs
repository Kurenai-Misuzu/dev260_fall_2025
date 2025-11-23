using System;
using System.Collections.Generic;
using System.Linq;

namespace FileSystemNavigator
{
    /// <summary>
    /// Binary Search Tree implementation for File System Navigation
    /// 
    /// STUDENT ASSIGNMENT: Implement the TODO methods in this class
    /// This class demonstrates BST concepts through a practical file system simulation
    /// 
    /// Learning Objectives:
    /// - Apply BST operations to hierarchical data
    /// - Implement complex search and filtering operations  
    /// - Practice file system concepts through tree structures
    /// - Build practical navigation and management tools
    /// </summary>
    public class FileSystemBST
    {
        private TreeNode? root;
        private int operationCount;
        private DateTime sessionStart;

        public FileSystemBST()
        {
            root = null;
            operationCount = 0;
            sessionStart = DateTime.Now;
            
            Console.WriteLine("🗂️  File System Navigator Initialized!");
            Console.WriteLine("📁 BST-based file system ready for operations.\n");
        }

        // ============================================
        // 🚀 STUDENT TODO METHODS - IMPLEMENT THESE
        // ============================================

        /// <summary>
        /// TODO #1: Create a new file in the file system
        /// 
        /// Requirements:
        /// - Insert file into BST maintaining proper ordering
        /// - Use file name for BST comparison (case-insensitive)
        /// - Handle duplicate file names (return false if exists)
        /// - Set appropriate file metadata (size, dates, extension)
        /// 
        /// BST Learning: Insertion with custom comparison logic
        /// Real-World: File creation in operating systems
        /// </summary>
        /// <param name="fileName">Name of file to create (e.g., "readme.txt")</param>
        /// <param name="size">File size in bytes (default 1024)</param>
        /// <returns>True if file created successfully, false if already exists</returns>
        public bool CreateFile(string fileName, long size = 1024)
        {
            operationCount++;
            
            // TODO: Implement file creation logic
            // Hints:
            // 1. Create FileNode with FileType.File and provided size
            // 2. Insert into BST using InsertNode helper method
            // 3. Handle duplicate file names (return false if exists)
            // 4. Extension will be automatically extracted in FileNode constructor
            
            // create new filenode with file filetype
            FileNode newFileNode = new FileNode(fileName, FileType.File, size);
            // check if there is a duplicate
            FileNode? dupeMaybe = SearchNode(root, fileName);
            // if dupe and the dupe is a file
            if ( dupeMaybe != null && dupeMaybe.Type == FileType.File)
            {
                // fail to create
                return false;
            }

            // inssert the node into the tree
            root = InsertNode(root, newFileNode);

            // success
            return true;
            
        }

        /// <summary>
        /// TODO #2: Create a new directory in the file system
        /// 
        /// Requirements:
        /// - Insert directory into BST with FileType.Directory
        /// - Directories should sort before files with same name
        /// - Set size to 0 for directories (automatic in FileNode constructor)
        /// - Handle duplicate directory names
        /// 
        /// BST Learning: Custom comparison for different node types
        /// Real-World: Directory creation and organization
        /// </summary>
        /// <param name="directoryName">Name of directory to create (e.g., "Documents")</param>
        /// <returns>True if directory created successfully, false if already exists</returns>
        public bool CreateDirectory(string directoryName)
        {
            operationCount++;
            
            // TODO: Implement directory creation logic
            // Hints:
            // 1. Create FileNode with FileType.Directory
            // 2. Use same insertion logic as CreateFile but with different type
            // 3. Directories automatically have size = 0 and no extension
            
            // create new filenode with directory type
            FileNode newDirectoryNode = new FileNode(directoryName, FileType.Directory, 0);
            // check for dupe
            FileNode? dupeMaybe = SearchNode(root, directoryName);
            // if dupe and dupe is a directory file type
            if ( dupeMaybe != null &&  dupeMaybe.Type == FileType.Directory)
            {
                // fail
                return false;
            }
            // insert directory
            root = InsertNode(root, newDirectoryNode);
            // succeed
            return true;

            
        }

        /// <summary>
        /// TODO #3: Find a specific file by exact name
        /// 
        /// Requirements:
        /// - Search BST efficiently using file name as key
        /// - Case-insensitive search
        /// - Return FileNode if found, null if not found
        /// - Use recursive BST search pattern
        /// 
        /// BST Learning: O(log n) search operations
        /// Real-World: File lookup in operating systems
        /// </summary>
        /// <param name="fileName">Name of file to find (not full path)</param>
        /// <returns>FileNode if found, null otherwise</returns>
        public FileNode? FindFile(string fileName)
        {
            operationCount++;
            
            // TODO: Implement file search logic
            // Hints:
            // 1. Use SearchNode helper method with recursive approach
            // 2. Compare file names case-insensitively
            // 3. Return the FileNode.FileData if found

            // search node with filename
            return SearchNode(root, fileName);
            
        }

        /// <summary>
        /// TODO #4: Find all files with a specific extension
        /// 
        /// Requirements:
        /// - Traverse entire BST collecting files with matching extension
        /// - Case-insensitive extension comparison (.txt = .TXT)
        /// - Return List of FileNode objects
        /// - Use in-order traversal for consistent ordering
        /// 
        /// BST Learning: Tree traversal with filtering
        /// Real-World: File type searches (find all .cs files)
        /// </summary>
        /// <param name="extension">File extension to search for (.txt, .cs, etc.)</param>
        /// <returns>List of files with matching extension</returns>
        public List<FileNode> FindFilesByExtension(string extension)
        {
            operationCount++;
            
            // TODO: Implement extension-based file search
            // Hints:
            // 1. Use TraverseAndCollect helper method
            // 2. Filter by FileType.File AND matching extension
            // 3. Handle extension format (with or without leading dot)

            // extension real is just extension with a '.' if there isn't one
            string extensionReal = extension;
            if (!extension.StartsWith(".")){
                extensionReal = "." + extension;
            }
            
            // filter function
            bool filter(FileNode fileNode)
            {
                // false if no extension
                if (extensionReal == null || string.Compare("", extensionReal) == 0)
                {
                    return false;
                }
                // if file is filetype file and ends with the extension
                if (fileNode.Name.EndsWith(extensionReal, StringComparison.OrdinalIgnoreCase) && fileNode.Type == FileType.File)
                {
                    return true;
                }
                return false;
            }

            // collection
            List<FileNode> collection = new List<FileNode>();

            // traverse and collect
            TraverseAndCollect(root, collection, filter);

            return collection;

            //throw new NotImplementedException("FindFilesByExtension method needs implementation");
        }

        /// <summary>
        /// TODO #5: Find all files within a size range
        /// 
        /// Requirements:
        /// - Search for files between minSize and maxSize (inclusive)
        /// - Only include FileType.File items (not directories)
        /// - Return files sorted by name (in-order traversal)
        /// - Handle edge cases (minSize > maxSize)
        /// 
        /// BST Learning: Range queries and filtered traversal
        /// Real-World: Find large files for cleanup, small files for compression
        /// </summary>
        /// <param name="minSize">Minimum file size in bytes</param>
        /// <param name="maxSize">Maximum file size in bytes</param>
        /// <returns>List of files within size range</returns>
        public List<FileNode> FindFilesBySize(long minSize, long maxSize)
        {
            operationCount++;
            
            // TODO: Implement size-based file search
            // Hints:
            // 1. Validate input parameters (min=Size <= maxSize)
            // 2. Use TraverseAndCollect with size range filter
            // 3. Only include FileType.File items
            // filter function

            // filter formula
            bool filter(FileNode fileNode)
            {
                // false if type isn't file
                if (fileNode.Type != FileType.File)
                {
                    // fail
                    return false;
                }

                // if filenode size is in range
                if (fileNode.Size >= minSize && fileNode.Size <= maxSize)
                {
                    // succeed
                    return true;
                }
                // else fail
                return false;
            }

            // collection
            List<FileNode> collection = new List<FileNode>();

            // traverse and collect
            TraverseAndCollect(root, collection, filter);

            return collection;

            
            //throw new NotImplementedException("FindFilesBySize method needs implementation");
        }

        /// <summary>
        /// TODO #6: Find the N largest files in the system
        /// 
        /// Requirements:
        /// - Collect all files and sort by size (descending)
        /// - Return top N largest files
        /// - Handle case where N > total file count
        /// - Only include FileType.File items
        /// 
        /// BST Learning: Tree traversal with post-processing
        /// Real-World: Disk cleanup utilities, storage analysis
        /// </summary>
        /// <param name="count">Number of largest files to return</param>
        /// <returns>List of largest files, sorted by size descending</returns>
        public List<FileNode> FindLargestFiles(int count)
        {
            operationCount++;
            
            // TODO: Implement largest files search
            // Hints:
            // 1. Collect all files using traversal
            // 2. Sort by Size property (descending)
            // 3. Take top 'count' items
            // 4. Handle edge case where count <= 0

            // filter forumula that returns every file
            bool filter(FileNode fileNode)
            {
                if (fileNode.Type == FileType.File)
                {
                    return true;   
                }
                return false;
            }

            // collection
            List<FileNode> collection = new List<FileNode>();
            // traverse and collect
            TraverseAndCollect(root, collection, filter);
            // sort
            collection.Sort((a, b) => b.Size.CompareTo(a.Size));

            // return entire collection if count is greater or if count is <= 0
            if (count > collection.Count || count <= 0)
            {
                return collection;
            }
           
            // remake list
            List<FileNode> newCollection = new List<FileNode>();

            // add to the collection depending on the count provided
            for (int i = 0; i < count; i++)
            {
                newCollection.Add(collection[i]);
            }
            return newCollection;
            
            //throw new NotImplementedException("FindLargestFiles method needs implementation");
        }

        /// <summary>
        /// TODO #7: Calculate total size of all files and directories
        /// 
        /// Requirements:
        /// - Traverse entire BST and sum all file sizes
        /// - Include both files and directories in count
        /// - Use recursive traversal approach
        /// - Return total size in bytes
        /// 
        /// BST Learning: Aggregation through tree traversal
        /// Real-World: Disk usage analysis, storage reporting
        /// </summary>
        /// <returns>Total size of all files in bytes</returns>
        public long CalculateTotalSize()
        {
            operationCount++;
            
            // TODO: Implement total size calculation
            // Hints:
            // 1. Use recursive helper method to traverse tree
            // 2. Sum the Size property of all nodes
            // 3. Handle empty tree case (return 0)


            // return every file
            bool filter(FileNode fileNode)
            {
                if (fileNode.Type == FileType.File)
                {
                    return true;   
                }
                return false;
            }

            // collection
            List<FileNode> collection = new List<FileNode>();
            // traverse and collect
            TraverseAndCollect(root, collection, filter);

            // if null collection return nothing
            if (collection == null)
            {
                return 0;
            }

            // sum total sizes
            long totalSize = 0;
            foreach (FileNode i in collection)
            {
                totalSize += i.Size;
            }

            return totalSize;

            
            //throw new NotImplementedException("CalculateTotalSize method needs implementation");
        }

        /// <summary>
        /// TODO #8: Delete a file or directory from the system
        /// 
        /// Requirements:
        /// - Remove item from BST maintaining tree structure
        /// - Handle all three deletion cases (no children, one child, two children)
        /// - Return true if deleted, false if not found
        /// - Use standard BST deletion algorithm
        /// 
        /// BST Learning: Complex deletion maintaining tree structure
        /// Real-World: File deletion in operating systems
        /// </summary>
        /// <param name="fileName">Name of file or directory to delete</param>
        /// <returns>True if deleted successfully, false if not found</returns>
        public bool DeleteItem(string fileName)
        {
            operationCount++;
            
            // TODO: Implement file/directory deletion
            // Hints:
            // 1. Find the node to delete first
            // 2. Handle three cases: no children, one child, two children
            // 3. For two children case, find inorder successor
            // 4. Update tree structure properly
            
            // this mess is the result of 3am coding i HAD to get this done before thanksgiving week started sorry
            // i think it works tho

            // get the parent of the node to delete
            TreeNode? parent = SearchForParent(root, fileName);
            // node to delete is set to root right now we will set it later
            TreeNode? nodeToDelete = root;
            // LR IS WHERE THE NODETODELETE IS IN RELATION TO THE PARENT
            // IF 0 THE THE CHILD IS TO THE LEFT OF THE PARENT IF 1 IT'S ON THE RIGHT
            int LR = 0;

            
            // if parent is null then we can't find the node to delete
            if (parent == null)
            {
                return false;
            }

            // if root is the one being deleted set nodetodelete to the parent
            if (parent == root && string.Compare(fileName.ToLower(), root.FileData.Name.ToLower()) == 0)
            {
                nodeToDelete = parent;
            }
            // check if nodetodleete is on right  of the parent
            if (parent.Right != null)
            {
                if (string.Compare(fileName.ToLower(), parent.Right.FileData.Name.ToLower()) == 0)
                {
                    // set node to delete and LR
                    nodeToDelete = parent.Right;
                    LR = 1;
                }
            }
            // check if nodetodelete is on the left of the parent
            if (parent.Left != null)
            {
                if (string.Compare(fileName.ToLower(), parent.Left.FileData.Name.ToLower()) == 0)
                {
                    // set node to delete LR
                    nodeToDelete = parent.Left;
                    LR = 0;
                }
            }
            
            // check children
            // NO Children
            if (nodeToDelete.Left == null && nodeToDelete.Right == null)
            {
                // IF ROOT set the root to null
                if (nodeToDelete == root)
                {
                    root = null;
                }
                // IF NOT ROOT
                // delete the parents left or right depending on where the child is
                else if (LR == 0)
                {
                    parent.Left = null;
                } 
                else
                {
                    parent.Right = null;
                }
            }
            // 2 CHILDREN
            else if (nodeToDelete.Left != null && nodeToDelete.Right != null) 
            {
                // find in order successor's parent
                parent = GetInorderSuccessorParent(nodeToDelete);

                // the successor will be set later
                TreeNode? successor = null;
                
                // mainly gets called if the root is the nodetodelete
                if (parent == nodeToDelete)
                {
                    // successor will always be to the right in this case because we are finding inorder successor
                    LR = 1;
                    successor = parent.Right;
                }
                else if (parent.Left == null)
                {
                    // child is to the right of parent
                    LR = 1;
                    successor = parent.Right;
                } 
                else
                {
                    // child is to the left of parent
                    LR = 0;
                    successor = parent.Left;
                }
                
                // swap node to delete and successor
                FileNode? temp = successor.FileData;
                successor.FileData = nodeToDelete.FileData;
                nodeToDelete.FileData = temp;

                // if successor child is on left
                if (successor.Right == null)
                {
                    if (LR == 0)
                    {
                        parent.Left = null;
                    }
                    else
                    {
                        parent.Right = null;
                    }
                    
                } else
                // successor child on right
                {
                    if (LR == 0)
                    {
                        parent.Left = successor.Right;
                    }
                    else
                    {
                        parent.Right = successor.Right;
                    }
                }
            
                
            }
            // 1 CHILD
            else
            {
                // IF THE CHILD OF THE NODE TO DELETE IS ON THE LEFT
                if (nodeToDelete.Right == null)
                {
                    // if root
                    if (nodeToDelete == root)
                    {
                        root = nodeToDelete.Left;
                    }
                    // IF NODE TO DELETE IS ON LEFT OR RIGHT
                    else if (LR == 0)
                    {
                        parent.Left = nodeToDelete.Left;
                    }
                    else
                    {
                        parent.Right = nodeToDelete.Left;
                    }
                } 
                // IF THE CHILD OF THE NODE TO DELETE IS ON THE RIGHT
                else
                {
                    // if root
                    if (nodeToDelete == root)
                    {
                        root = nodeToDelete.Right;
                    }
                    // IF NODE TO DELETE IS ON LEFT OR RIGHT
                    else if (LR == 0)
                    {
                        parent.Left = nodeToDelete.Right;
                    }
                    else
                    {
                        parent.Right = nodeToDelete.Right;
                    }
                }

            }

            return true;
            
            //throw new NotImplementedException("DeleteItem method needs implementation");
        }

        // ============================================
        // 🔧 HELPER METHODS FOR TODO IMPLEMENTATION
        // ============================================
        
        /// <summary>
        /// Helper method for BST insertion
        /// Students should use this in CreateFile and CreateDirectory
        /// </summary>
        private TreeNode? InsertNode(TreeNode? node, FileNode fileData)
        {
            // TODO: Implement recursive BST insertion
            // Base case: if node is null, create new TreeNode
            // Recursive case: compare names and go left or right
            // Use CompareFileNodes for proper ordering
            
            // return new if null
            if (node == null)
            {
                return new TreeNode(fileData);
            }
            // less than
            if (string.Compare(fileData.Name, node.FileData.Name) < 0 || (string.Compare(fileData.Name, node.FileData.Name) == 0 && fileData.Type == FileType.Directory))
            {
                node.Left = InsertNode(node.Left, fileData);
            }
            // greater than
            else if (string.Compare(fileData.Name, node.FileData.Name) > 0 || (string.Compare(fileData.Name, node.FileData.Name) == 0 && fileData.Type == FileType.File))
            {
                node.Right = InsertNode(node.Right, fileData);
            }

            return node;

            //throw new NotImplementedException("InsertNode helper method needs implementation");
        }

        /// <summary>
        /// Helper method for BST searching
        /// Students should use this in FindFile
        /// </summary>
        private FileNode? SearchNode(TreeNode? node, string fileName)
        {
            // TODO: Implement recursive BST search
            // Base case: if node is null, return null
            // Base case: if names match, return node.FileData
            // Recursive case: compare names and go left or right

            if (node == null)
            {
                return null;
            }

            // less than
            if (string.Compare(fileName.ToLower(), node.FileData.Name.ToLower()) < 0)
            {
                return SearchNode(node.Left, fileName);
            }
            // greater than
            else if (string.Compare(fileName.ToLower(), node.FileData.Name.ToLower()) > 0)
            {
                return SearchNode(node.Right, fileName);    
            }
            // found
            else if (string.Compare(fileName.ToLower(), node.FileData.Name.ToLower()) == 0 )
            {
                return node.FileData;
            }

            return null;
            //throw new NotImplementedException("SearchNode helper method needs implementation");
        }

        /// <summary>
        /// Helper method for collecting nodes during traversal
        /// Students should use this for FindFilesByExtension, FindFilesBySize, etc.
        /// </summary>
        private void TraverseAndCollect(TreeNode? node, List<FileNode> collection, Func<FileNode, bool> filter)
        {
            // TODO: Implement in-order traversal with filtering
            // Base case: if node is null, return
            // Recursive case: traverse left, process current, traverse right
            // Add to collection only if filter returns true

            // if node is null return
            if (node == null)
            {
                return;
            }

            // traverse all the way to the left
            TraverseAndCollect(node.Left, collection, filter);
            
            // if the function returns true add it to the collection
            if (filter(node.FileData))
            {
                collection.Add(node.FileData);
            }

            // traverse all the way to the right
            TraverseAndCollect(node.Right, collection, filter);



            //throw new NotImplementedException("TraverseAndCollect helper method needs implementation");
        }

        // CUSTOMER USER HELPER FUNCTION: SEARCHES FOR THE PARENT OF THE ONE WITH THE FILENAME
        private TreeNode? SearchForParent(TreeNode? node, string fileName)
        {
            // return null if node is null
            if (node == null)
            {
                return null;
            }

            // if headnode is to be deleted
            if (string.Compare(fileName.ToLower(), node.FileData.Name.ToLower()) == 0)
            {
                return node;
            }

            // FOUND ON RIGHT NODE
            if (node.Right != null)
            {
                if (string.Compare(fileName.ToLower(), node.Right.FileData.Name.ToLower()) == 0)
                {
                    return node;
                }
            }

            // FOUND ON LEFT NODE
            if (node.Left != null)
            {
                if (string.Compare(fileName.ToLower(), node.Left.FileData.Name.ToLower()) == 0)
                {
                    return node;
                }
            }

            // traverse hierchy
            if (string.Compare(fileName.ToLower(), node.FileData.Name.ToLower()) < 0)
            {
                return SearchForParent(node.Left, fileName);
            }
            else if (string.Compare(fileName.ToLower(), node.FileData.Name.ToLower()) > 0)
            {
                return SearchForParent(node.Right, fileName);    
            }
            return null;

        }

        // CUSTOM HELPER FUNCTION: GETS THE PARENT OF THE SUCCESSOR
        private TreeNode? GetInorderSuccessorParent(TreeNode? node)
        {
            // if node right isn't null and node right left isn't, then must be the parent of successor
            if (node.Right != null && node.Right.Left == null)
            {
                return node;
            }

            // move right
            node = node.Right;

            // keep traversing left while the left node isn't null and the left node's left isn't null
            // remember we're finding the PARENT of the successor here
            while (node != null && node.Left != null && node.Left.Left != null)
            {
                node = node.Left;
            }
            return node;
        }

        /// <summary>
        /// Custom comparison method for file system ordering
        /// Directories come before files, then alphabetical by name
        /// </summary>
        private int CompareFileNodes(FileNode a, FileNode b)
        {
            // Directories sort before files
            if (a.Type != b.Type)
                return a.Type == FileType.Directory ? -1 : 1;
            
            // Then alphabetical by name (case-insensitive)
            return string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase);
        }

        // ============================================
        // 🎯 PROVIDED UTILITY METHODS
        // ============================================

        /// <summary>
        /// Display the file system tree structure visually
        /// Helps students visualize their BST structure
        /// </summary>
        public void DisplayTree()
        {
            Console.WriteLine("🌳 File System Tree Structure:");
            Console.WriteLine("================================");
            
            if (root == null)
            {
                Console.WriteLine("   (Empty file system)");
                return;
            }
            DisplayTreeEnhanced(root, "", true, true);
            Console.WriteLine("================================\n");
            Console.WriteLine("🌲 Horizontal Level-by-Level View:");
            DisplayTreeByLevels();
        }

        /// <summary>
        /// Enhanced tree display with better visual formatting and clear parent-child relationships
        /// </summary>
        private void DisplayTreeEnhanced(TreeNode? node, string prefix, bool isLast, bool isRoot)
        {
            if (node == null) return;

            // Display current node with enhanced formatting
            string connector = isRoot ? "🌟 " : (isLast ? "└── " : "├── ");
            string nodeInfo = $"{node.FileData.Name}{(node.FileData.Type == FileType.Directory ? "/" : $" ({FormatSize(node.FileData.Size)})")}";
            
            Console.WriteLine(prefix + connector + nodeInfo);

            // Update prefix for children
            string childPrefix = prefix + (isRoot ? "" : (isLast ? "    " : "│   "));

            // Display children with clear Left/Right indicators
            bool hasLeft = node.Left != null;
            bool hasRight = node.Right != null;

            if (hasRight)
            {
                Console.WriteLine(childPrefix + "│");
                Console.WriteLine(childPrefix + "├─(R)─┐");
                DisplayTreeEnhanced(node.Right, childPrefix + "│     ", !hasLeft, false);
            }

            if (hasLeft)
            {
                Console.WriteLine(childPrefix + "│");
                Console.WriteLine(childPrefix + "└─(L)─┐");
                DisplayTreeEnhanced(node.Left, childPrefix + "      ", true, false);
            }
        }

        /// <summary>
        /// Display tree in a horizontal level-by-level format
        /// </summary>
        private void DisplayTreeByLevels()
        {
            if (root == null) return;

            var queue = new Queue<(TreeNode?, int)>();
            queue.Enqueue((root, 0));
            int currentLevel = -1;

            while (queue.Count > 0)
            {
                var (node, level) = queue.Dequeue();
                
                if (level > currentLevel)
                {
                    if (currentLevel >= 0) Console.WriteLine();
                    Console.Write($"Level {level}: ");
                    currentLevel = level;
                }

                if (node != null)
                {
                    Console.Write($"[{node.FileData.Name}{(node.FileData.Type == FileType.Directory ? "/" : "")}] ");
                    queue.Enqueue((node.Left, level + 1));
                    queue.Enqueue((node.Right, level + 1));
                }
                else
                {
                    Console.Write("[null] ");
                }
            }
            Console.WriteLine();
        }


        private string FormatSize(long bytes)
        {
            if (bytes < 1024) return $"{bytes}B";
            if (bytes < 1024 * 1024) return $"{bytes / 1024}KB";
            return $"{bytes / (1024 * 1024)}MB";
        }

        /// <summary>
        /// Get comprehensive statistics about the file system
        /// </summary>
        public FileSystemStats GetStatistics()
        {
            var stats = new FileSystemStats
            {
                TotalOperations = operationCount,
                SessionDuration = DateTime.Now - sessionStart
            };

            if (root != null)
            {
                CalculateStats(root, stats);
            }

            return stats;
        }

        private void CalculateStats(TreeNode? node, FileSystemStats stats)
        {
            if (node == null) return;

            var file = node.FileData;
            if (file.Type == FileType.File)
            {
                stats.TotalFiles++;
                stats.TotalSize += file.Size;
                
                if (file.Size > stats.LargestFileSize)
                {
                    stats.LargestFileSize = file.Size;
                    stats.LargestFile = file.Name;
                }
            }
            else
            {
                stats.TotalDirectories++;
            }

            CalculateStats(node.Left, stats);
            CalculateStats(node.Right, stats);
        }

        /// <summary>
        /// Check if the file system is empty
        /// </summary>
        public bool IsEmpty() => root == null;

        /// <summary>
        /// Load sample data for testing and demonstration
        /// </summary>
        public void LoadSampleData()
        {
            Console.WriteLine("📁 Loading sample file system data...");
            
            // Sample directories
            var sampleDirs = new[]
            {
                "Documents", "Pictures", "Videos", "Music", "Downloads",
                "Projects", "Code", "Images", "Archive"
            };

            // Sample files with extensions and sizes
            var sampleFiles = new[]
            {
                ("readme.txt", 2048L), ("config.json", 1024L), ("app.cs", 5120L),
                ("photo.jpg", 2048000L), ("song.mp3", 4096000L), ("video.mp4", 52428800L),
                ("document.pdf", 1048576L), ("presentation.pptx", 3145728L),
                ("spreadsheet.xlsx", 512000L), ("archive.zip", 10485760L)
            };

            try
            {
                // Create directories
                foreach (var dir in sampleDirs.Take(6))
                {
                    CreateDirectory(dir);
                }

                // Create files
                foreach (var (fileName, size) in sampleFiles.Take(8))
                {
                    CreateFile(fileName, size);
                }

                Console.WriteLine("✅ Sample data loaded successfully!");
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("⚠️  Cannot load sample data - TODO methods not implemented yet");
            }
        }
    }
}