/**
 * Event.js
 *
 * @description :: TODO: You might write a short summary of how this model works and what it represents here.
 * @docs        :: http://sailsjs.org/documentation/concepts/models-and-orm/models
 */

module.exports = {
  tableName:'Event',
  attributes: {
    deleted: 'bool',
    createtime: 'datetime',
    creator: 'string',
    modifietime: 'datetime',
    revisor: 'string',
    machine: 'string',
    eventType: 'string',
    eventID: 'string',
    eventGroup: 'string',
    unitID: 'string',
    slotID: 'string',
    date: 'date',
    time: 'datetime',
    message: 'string',
    datetime:'datetime'
  }
};

