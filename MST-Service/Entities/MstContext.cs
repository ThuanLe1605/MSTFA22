using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MST_Service.Entities;

public partial class MstContext : DbContext
{
    public MstContext()
    {
    }

    public MstContext(DbContextOptions<MstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<BookingStatus> BookingStatuses { get; set; }

    public virtual DbSet<Demand> Demands { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<GradeSyllabus> GradeSyllabi { get; set; }

    public virtual DbSet<Lecture> Lectures { get; set; }

    public virtual DbSet<LectureDocument> LectureDocuments { get; set; }

    public virtual DbSet<LectureGrade> LectureGrades { get; set; }

    public virtual DbSet<LectureSubject> LectureSubjects { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Slot> Slots { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Syllabus> Syllabi { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<Wallet> Wallets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Address__3214EC0744177548");

            entity.ToTable("Address");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ApartmentNumber).HasMaxLength(256);
            entity.Property(e => e.City).HasMaxLength(256);
            entity.Property(e => e.District).HasMaxLength(256);
            entity.Property(e => e.Street).HasMaxLength(256);
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Booking__3214EC079FD983C8");

            entity.ToTable("Booking");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BookingAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.BookingStatus).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.BookingStatusId)
                .HasConstraintName("FK__Booking__Booking__6477ECF3");

            entity.HasOne(d => d.Lecture).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.LectureId)
                .HasConstraintName("FK__Booking__Lecture__60A75C0F");

            entity.HasOne(d => d.Payment).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK__Booking__Payment__628FA481");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Booking__UserId__619B8048");
        });

        modelBuilder.Entity<BookingStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BookingS__3214EC072315BBA1");

            entity.ToTable("BookingStatus");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(256);
        });

        modelBuilder.Entity<Demand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Demand__3214EC076AB2B50A");

            entity.ToTable("Demand");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Gender).WithMany(p => p.Demands)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK__Demand__GenderId__59063A47");

            entity.HasOne(d => d.Grade).WithMany(p => p.Demands)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Demand__GradeId__5629CD9C");

            entity.HasOne(d => d.Subject).WithMany(p => p.Demands)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Demand__SubjectI__571DF1D5");

            entity.HasOne(d => d.Syllabus).WithMany(p => p.Demands)
                .HasForeignKey(d => d.SyllabusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Demand__Syllabus__5812160E");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3214EC071F695478");

            entity.ToTable("Document");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Event__3214EC07FC260C3C");

            entity.ToTable("Event");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.StartDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Promotion).WithMany(p => p.Events)
                .HasForeignKey(d => d.PromotionId)
                .HasConstraintName("FK__Event__Promotion__6B24EA82");

            entity.HasMany(d => d.Users).WithMany(p => p.Events)
                .UsingEntity<Dictionary<string, object>>(
                    "UserEvent",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UserEvent__UserI__6FE99F9F"),
                    l => l.HasOne<Event>().WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UserEvent__Event__6EF57B66"),
                    j =>
                    {
                        j.HasKey("EventId", "UserId").HasName("PK__UserEven__A83C44D440067545");
                        j.ToTable("UserEvent");
                    });
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Feedback__3214EC07AC5FB82A");

            entity.ToTable("Feedback");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Lecture).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.LectureId)
                .HasConstraintName("FK__Feedback__Lectur__403A8C7D");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Feedback__UserId__3F466844");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Gender__3214EC073333DDE9");

            entity.ToTable("Gender");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(256);
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Grade__3214EC07B7E16919");

            entity.ToTable("Grade");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(266);
        });

        modelBuilder.Entity<GradeSyllabus>(entity =>
        {
            entity.HasKey(e => new { e.GradeId, e.SyllabusId }).HasName("PK__GradeSyl__2D407B3D318D6CA1");

            entity.ToTable("GradeSyllabus");

            entity.Property(e => e.Ratio).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Grade).WithMany(p => p.GradeSyllabi)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GradeSyll__Grade__5165187F");

            entity.HasOne(d => d.Syllabus).WithMany(p => p.GradeSyllabi)
                .HasForeignKey(d => d.SyllabusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GradeSyll__Sylla__52593CB8");
        });

        modelBuilder.Entity<Lecture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lecture__3214EC07EB5F98F0");

            entity.ToTable("Lecture");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AvatarUrl).IsUnicode(false);
            entity.Property(e => e.FirstName).HasMaxLength(256);
            entity.Property(e => e.LastName).HasMaxLength(266);

            entity.HasOne(d => d.Gender).WithMany(p => p.Lectures)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK__Lecture__GenderI__3C69FB99");
        });

        modelBuilder.Entity<LectureDocument>(entity =>
        {
            entity.HasKey(e => new { e.LectureId, e.DocumentId }).HasName("PK__LectureD__5692184F4B2C90D1");

            entity.ToTable("LectureDocument");

            entity.HasOne(d => d.Document).WithMany(p => p.LectureDocuments)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LectureDo__Docum__7B5B524B");

            entity.HasOne(d => d.Lecture).WithMany(p => p.LectureDocuments)
                .HasForeignKey(d => d.LectureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LectureDo__Lectu__7A672E12");
        });

        modelBuilder.Entity<LectureGrade>(entity =>
        {
            entity.HasKey(e => new { e.LectureId, e.GradeId }).HasName("PK__LectureG__D276711AD0D033C7");

            entity.ToTable("LectureGrade");

            entity.HasOne(d => d.Grade).WithMany(p => p.LectureGrades)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LectureGr__Grade__45F365D3");

            entity.HasOne(d => d.Lecture).WithMany(p => p.LectureGrades)
                .HasForeignKey(d => d.LectureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LectureGr__Lectu__44FF419A");
        });

        modelBuilder.Entity<LectureSubject>(entity =>
        {
            entity.HasKey(e => new { e.LectureId, e.SubjectId }).HasName("PK__LectureS__2DF84C859533686B");

            entity.ToTable("LectureSubject");

            entity.HasOne(d => d.Lecture).WithMany(p => p.LectureSubjects)
                .HasForeignKey(d => d.LectureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LectureSu__Lectu__4AB81AF0");

            entity.HasOne(d => d.Subject).WithMany(p => p.LectureSubjects)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LectureSu__Subje__4BAC3F29");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payment__3214EC071EC5DC08");

            entity.ToTable("Payment");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IsPayment).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Promotio__3214EC079D51FE5F");

            entity.ToTable("Promotion");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(256);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC076B4B9F88");

            entity.ToTable("Role");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Schedule__3214EC07053D39A3");

            entity.ToTable("Schedule");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Lecture).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.LectureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Schedule__Lectur__778AC167");

            entity.HasOne(d => d.Slot).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.SlotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Schedule__SlotId__74AE54BC");

            entity.HasOne(d => d.Subject).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Schedule__Subjec__75A278F5");

            entity.HasOne(d => d.User).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Schedule__UserId__76969D2E");
        });

        modelBuilder.Entity<Slot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Slot__3214EC070C5F43F8");

            entity.ToTable("Slot");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subject__3214EC075B6C1AAA");

            entity.ToTable("Subject");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(266);
        });

        modelBuilder.Entity<Syllabus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Syllabus__3214EC078643BEB7");

            entity.ToTable("Syllabus");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transact__3214EC075ED00656");

            entity.ToTable("Transaction");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Wallet).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.WalletId)
                .HasConstraintName("FK__Transacti__Walle__30F848ED");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC07D4CC4C1F");

            entity.ToTable("User");

            entity.HasIndex(e => e.Username, "UQ__User__536C85E41ABBF7E8").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__User__A9D105348010F57C").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AvatarUrl).IsUnicode(false);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FirstName).HasMaxLength(256);
            entity.Property(e => e.LastName).HasMaxLength(266);
            entity.Property(e => e.Password).HasMaxLength(256);
            entity.Property(e => e.Username)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.HasOne(d => d.Address).WithMany(p => p.Users)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK__User__AddressId__2A4B4B5E");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId }).HasName("PK__UserRole__AF2760ADABFB631F");

            entity.ToTable("UserRole");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserRole__RoleId__34C8D9D1");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserRole__UserId__33D4B598");
        });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Wallet__3214EC07820D0C74");

            entity.ToTable("Wallet");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithMany(p => p.Wallets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Wallet__UserId__2D27B809");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
