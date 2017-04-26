/**
 * EventController
 *
 * @description :: Server-side logic for managing events
 * @help        :: See http://sailsjs.org/#!/documentation/concepts/Controllers
 */

module.exports = {
  FindAll:function(req,res) {
    Event.find().exec(function (err, events) {
      if(err)
        return res.json({ err: err }, 500);
      else
        res.json(events);
    });

  },

  FindByEventType: function (req, res) {
    Event.find({ eventType: req.params.eventType }).exec(function (err, events) {
      if(err)
        return res.json({ err: err }, 500);
      else
        res.json(events);
    });
  },

  FindByEventGroup: function (req, res) {
    Event.find({ eventGroup: req.params.eventGroup }).exec(function (err, events) {
      if(err)
        return res.json({ err: err }, 500);
      else
        res.json(events);
    });
  },

  FindByMessage: function (req, res) {
    Event.find({
      message: {
        'contains': req.params.message
      }
    }).exec(function (err, events) {
      if(err)
        return res.json({ err: err }, 500);
      else
        res.json(events);
    });
  },

  FindByTime: function (req, res) {
    Event.find({
      datetime: {
        '>=': new Date(req.query.st),
        '<=': new Date(req.query.et)
      }
    }).exec(function (err, events) {
      if(err)
        return res.json({ err: err }, 500);
      else
        res.json(events);
    });
  },

  Search: function (req, res) {
    if((req.query.eventType =='ALL' || req.query.eventType =='') && req.query.message == '') {
      Event.find({
        datetime: {
          '>=': new Date(req.query.st),
          '<=': new Date(req.query.et)
        }
      }).exec(function (err, events) {
        if(err)
          return res.json({ err: err }, 500);
        else
          res.json(events);
      });
    }
    else if(req.query.eventType !='ALL' && req.query.eventType != '' && req.query.message != ''){
      Event.find({
        datetime: {
          '>=': new Date(req.query.st),
          '<=': new Date(req.query.et)
        },
        eventType: req.query.eventType,
        message: {
          'contains': req.query.message
        }
      }).exec(function (err, events) {
        if(err)
          return res.json({ err: err }, 500);
        else
          res.json(events);
      });
    }
    else if(req.query.eventType !='ALL' && req.query.eventType != '' && req.query.message == ''){
      Event.find({
        datetime: {
          '>=': new Date(req.query.st),
          '<=': new Date(req.query.et)
        },
        eventType: req.query.eventType
      }).exec(function (err, events) {
        if(err)
          return res.json({ err: err }, 500);
        else
          res.json(events);
      });
    }
    else if((req.query.eventType =='ALL' || req.query.eventType =='') && req.query.message != ''){
      Event.find({
        datetime: {
          '>=': new Date(req.query.st),
          '<=': new Date(req.query.et)
        },
        message: {
          'contains': req.query.message
        }
      }).exec(function (err, events) {
        if(err)
          return res.json({ err: err }, 500);
        else
          res.json(events);
      });
    }

  }

};

