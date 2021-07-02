#pragma once

#include "Activitati.h"
#include "RepoFile.h"
#include "Domain.h"

class ActiuneUndo {
	public:
		virtual void doUndo() = 0;
		virtual ~ActiuneUndo() = default;
};

class UndoAdd : public ActiuneUndo {
	string title, description;
	ActRepo& repo;

	public:
		UndoAdd(ActRepo& repo, const string& title, const string& description) : repo{ repo }, title{ title }, description{ description }{};

		void doUndo() override {
			repo.remove(title, description);
		}
};

class UndoRem : public ActiuneUndo {
	Activity act;
	ActRepo& repo;
	
	public:
		UndoRem(ActRepo& repo, Activity act) : repo{ repo }, act{ act }{};
		
		void doUndo() override {
			repo.add(act);
		}
};

class UndoMod : public ActiuneUndo {
	string title, description, type;
	int length;
	ActRepo& repo;

	public:
		UndoMod(ActRepo& repo, const string& title, const string& description, const string& type, const int& length) : repo{ repo }, title{ title }, description{ description }, type{ type }, length{ length }{};

		void doUndo() override {
			repo.modify(title, description, type, length);
		}
};