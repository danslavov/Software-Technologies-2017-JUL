const Task = require('../models/Task');

module.exports = {

    index: (req, res) => {
        Task.find({}).then(tasks => {
            res.render("task/index", {
                "openTasks": tasks.filter(t => t.status === "Open"),
                "inProgressTasks": tasks.filter(t => t.status === "In Progress"),
                "finishedTasks": tasks.filter(t => t.status === "Finished")
            });
        });
    },

    createGet: (req, res) => {
        res.render("task/create");
    },
    createPost: (req, res) => {
        let newTask = req.body;
        Task.create(newTask).then(task => {
            res.redirect("/");
        }).catch(err => {
            newTask.error = "Cannot create task.";
            res.render("task/create", newTask);
        });
    },

    editGet: (req, res) => {
        let taskId = req.params.id;
        let taskArguments = req.body;
        Task.findById(taskId).then(task => {
            if (task) {
                res.render("task/edit", {"title": task.title, "status": task.status});
            } else {
                res.redirect("/");
            }
        }).catch(err => {
            res.redirect("/");
        });
    },

    editPost: (req, res) => {
        let taskId = req.params.id;
        let taskArguments = req.body;
        Task.findByIdAndUpdate(taskId, taskArguments,
            {runValidators: true}).then(task => {
            res.redirect("/");
        }).catch(err => {
            taskArguments.error = "Cannot edit task.";
            res.render("task/edit", taskArguments);
        });
    }
};