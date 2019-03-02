# HIMS.EF 
Human resource management system  :books:

1) How to resolve issue with PK in views generated by EF? 
- Read following links to figure it out and apply to your part of solution:
https://stackoverflow.com/questions/24792259/error-6002-the-table-view-does-not-have-a-primary-key-defined
https://www.dustinhorne.com/post/2016/12/10/views-and-incorrect-data-in-entity-framework

2) Good tutorial in ENGLISH to read about EF
http://www.entityframeworktutorial.net

3) If you add new entity, procedure, view and etc., you need:
	a) run script to add it to database on your local server
	b) save script in HIMS.Database solution in an appropriate folder
	c) update your HIMS.edmx model from your database
	d) commit your changes

4) Git workflow
	4.1 name of branch: <your-name><feature>

	4.2
	git checkout dev
	git pull (resolve conflicts if need)
	
	git checkout -b <your-branch-name>
	git status
	git add . / git add "<name-of-file>"
	git commit -m "<your-commit>"
	git push -u origin <your-branch-name>  // -u or --set-upstream
	
	git checkout dev
	git pull (resolve conflicts if need)
	git merge <your-branch> dev
	git branch -d <your-branch>
	
	https://rogerdudler.github.io/git-guide/ - refresh you git knowledges step by step

5) How to work with procedures in EF? (Need to add)
