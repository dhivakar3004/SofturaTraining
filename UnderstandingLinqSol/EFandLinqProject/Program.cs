using EFandLinqProject.model;
using System;
using System.Linq;

namespace EFandLinqProject
{
    class Program
    {
        PostRepo postRepo;
        CommentRepo commentRepo;
        TweetContext context;
        Program()
        {
            context = new TweetContext();
            commentRepo = new CommentRepo(context);
            postRepo = new PostRepo(context);
        }
        void PrintPostWithComments()
        {
            var postWiseComment = context.Comments.GroupBy(c => c.PostId);
            foreach (var postComment in postWiseComment)
            {
                int id = postComment.Key;
                Post post = postRepo.Get(id);
                PrintPost(post);
                Console.WriteLine("Comment for this post");
                foreach (var comment in postComment)
                {
                    PrintComment(comment);

                }
                Console.WriteLine("----------------------------------");

            }
        }
        public void PrintComment(Comment comment)
        {
            Console.WriteLine("Comment id "+ comment.Id);
            Console.WriteLine(comment.CommenText);
        }
        void AddPost()
        {   
            Console.WriteLine("Please Enter the Post Category");
            String category = Console.ReadLine();
            Console.WriteLine("Please Enter the Post Text");
            String text = Console.ReadLine();
            Post post = new Post();
            post.Category = category;
            post.PostText = text;
            if(postRepo.Add(post))
                Console.WriteLine("The post is posted");
            else
                Console.WriteLine("Could not post");
        }
        public void PrintPosts()
        {
            var posts = postRepo.GetAll();
            if(posts != null)
                foreach (var item in posts.ToList())
                {
                    PrintPost(item);
                }         
            
        }
        void PrintPost(Post post)
        {
            Console.WriteLine("Post Id" + post.Id);
            Console.WriteLine("Post Category" + post.Category);
            Console.WriteLine("Post" + post.PostText);
        }
        void AddCommentToPost()
        {
            PrintPosts();
            int id = 0;
            Console.WriteLine("Please Enter the id for which you want to comment");
            id = Convert.ToInt32(Console.ReadLine());
            Post post = postRepo.Get(id);
            if(post!=null)
            {
                PrintPost(post);
                Comment comment = TakeComment(id);
                if(commentRepo.Add(comment))
                {
                    Console.WriteLine("Comment Updated");
                }
            }

        }
        private Comment TakeComment(int pid)
        {
            Comment comment = new Comment();
            comment.PostId = pid;
            Console.WriteLine("Please enter the comment");
            comment.CommenText = Console.ReadLine();
            return comment;
        }
        void UserInterface()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
