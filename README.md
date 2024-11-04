# CLDV7111wPOE
### KhumaloCraft Emporium is an online destination for exquisite handcrafted goods and unique artisanal creations.
#### Welcome to the project! This guide will help you get started with GitHub. Follow these steps to clone the repository, create a branch, add changes, and contribute to the project.
---

## GitHub Quick Start Guide

Prerequites: 
- [Download & Install Git](https://git-scm.com/)

Helpful links:
- [Git Tutorial for Absolute Beginners](https://www.youtube.com/watch?v=CvUiKWv2-C0)
- [Git and GitHub Tutorial](https://www.freecodecamp.org/news/git-and-github-for-beginners/)
- [Branch naming convensions](https://medium.com/@abhay.pixolo/naming-conventions-for-git-branches-a-cheatsheet-8549feca2534)

## 1. Clone the Repository

First, you'll need to clone the repository to your local machine. This creates a local copy of the repository that you can work on.

1. Go to the repository page on GitHub.
2. Click the green **Code** button and copy the URL (either HTTPS or SSH).
3. Open a terminal on your local machine and run the following command:

```bash
git clone <repository-url>
```

## 2. Create a New Branch

Before making changes, create a new branch. This keeps your changes separate from the main branch.

1. Navigate to the cloned repository directory:

```bash
cd <repository-name>
```

Replace <repository-name> with the name of the cloned repository.

2. Create a new branch and switch to it:

```bash
git checkout -b <branch-name>
```


## 3. Add & Commit Changes

After making changes to files, you'll need to stage and commit them.

1. Stage the changes:

```bash
git add .
```

2. Commit the changes with a descriptive message:

```bash
git commit -m "Your commit message"
```

## 4. Push the Branch to GitHub
Push your new branch to GitHub so others can see it and review your changes.

```bash
git push -u origin <branch-name>
```

## 5. Create a Pull Request
To merge your changes into the main branch, create a pull request.

1. Go to the repository page on GitHub.
2. You should see a prompt to create a pull request for your recently pushed branch. Click Compare & pull request.
3. Add a title and description for your pull request.
4. Click Create pull request.

## 6. Review and Merge
Once you've created a pull request, team members can review your changes. After the review, a team member with write access will merge your pull request into the main branch.