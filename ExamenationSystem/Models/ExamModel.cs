namespace ExaminationSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ExamModel : DbContext
    {
        public ExamModel()
            : base("name=ExamModel")
        {
        }

        public virtual DbSet<Exam_Questions> Exam_Questions { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<StdsAnswer> StdsAnswers { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>()
                .HasMany(e => e.Exam_Questions)
                .WithRequired(e => e.Exam)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Exam>()
                .HasMany(e => e.StdsAnswers)
                .WithRequired(e => e.Exam)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Instructor>()
                .HasMany(e => e.Subjects)
                .WithMany(e => e.Instructors)
                .Map(m => m.ToTable("Subjects_Instructors").MapLeftKey("Inst_Id").MapRightKey("Sub_Id"));

            modelBuilder.Entity<Question>()
                .Property(e => e.Type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Image)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Exam_Questions)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.StdsAnswers)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.StdsAnswers)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Tracks)
                .WithMany(e => e.Subjects1)
                .Map(m => m.ToTable("Tracks_Subjects").MapLeftKey("Sub_Id").MapRightKey("Trs_Id"));

            modelBuilder.Entity<Track>()
                .HasMany(e => e.Instructors)
                .WithOptional(e => e.Track)
                .HasForeignKey(e => e.Track_Id);

            modelBuilder.Entity<Track>()
                .HasMany(e => e.Subjects)
                .WithOptional(e => e.Track)
                .HasForeignKey(e => e.Track_Id);

            modelBuilder.Entity<Type>()
                .Property(e => e.Type_Id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Type>()
                .Property(e => e.Image)
                .IsFixedLength();

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Questions)
                .WithRequired(e => e.Type1)
                .HasForeignKey(e => e.Type)
                .WillCascadeOnDelete(false);
        }
    }
}
