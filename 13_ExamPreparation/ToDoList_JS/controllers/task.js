const Task = require('../models/Task');

module.exports = {

    index: (req, res) => {
        Task.find({}).then(tasks => {
            res.render('task/index', {'tasks': tasks});
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

    deleteGet: (req, res) => {
        let taskId = req.params.id;
        Task.findById(taskId).then(taskToDelete => {
            if (taskToDelete) {
                res.render("task/delete", taskToDelete);
            } else {
                res.redirect("/");
            }
        }).catch(err => {
            res.redirect("/");
        });
    },

    deletePost: (req, res) => {
        let taskId = req.params.id;
        Task.findByIdAndRemove(taskId, {runValidators: true}).then(task => {
            res.redirect("/");
        }).catch(err => {
            res.redirect("/");
        });
    }
};