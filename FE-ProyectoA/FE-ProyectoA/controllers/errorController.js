exports.Get404 = ((req, res, next) => {
    res.status(404).render('errors/404', { title: "404 not found" });
});