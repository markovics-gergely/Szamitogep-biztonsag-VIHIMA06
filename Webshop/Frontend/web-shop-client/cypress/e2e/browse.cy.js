/* eslint-disable no-undef */
const uuid = () => Cypress._.random(0, 1e6);
const testname = `testname${uuid()}`;
const testNewname = `testNewname${uuid()}`;
const testBuyname = `testBuyname${uuid()}`;

describe('testing browser', () => {
  beforeEach(() => {
    cy.login('Admin', '@Admin1234');
    cy.visit('/browse');
    cy.get('#sizes').should('be.visible').select('100');
    cy.wait(1000);
  });

  it('create caff', () => {
    cy.get('[data-cy=add-button]', { timeout: 5000 }).click();
    cy.get('[data-cy=add-form]').should('be.visible');
    cy.wait(200);
    cy.get('[data-cy=add-form] > #title').click().type(testname).should('have.value', testname);
    cy.wait(200);
    cy.get('[data-cy=add-form] > #description').click().type('Description').should('have.value', 'Description');
    cy.wait(200);
    cy.get('#upload').selectFile('cypress/fixtures/2.caff', { force: true });
    cy.get('#submit').click();
    cy.location('pathname').should('contain', '/browse/');
    cy.visit('/browse');
    cy.get('.caff-title', { timeout: 15000 }).should('contain', testname);
  });

  it('add comment', () => {
    cy.get('[data-cy=caff-list] > .caff', { timeout: 15000 }).should('have.length.at.least', 1);
    cy.get('.caff-title', { timeout: 15000 }).contains(testname).click({ force: true });
    cy.location('pathname').should('contain', '/browse/');
    cy.get('#comment-form').should('be.visible');
    cy.wait(200);
    cy.get('#comment-form').find('#text').click().type('Example comment').should('have.value', 'Example comment');
    cy.wait(200);
    cy.get('#comment-submit').click();
    cy.wait(200);
    cy.get('.comment > .text', { timeout: 15000 }).should('contain', 'Example comment');
  });

  it('edit caff', () => {
    cy.get('.caff-title', { timeout: 15000 }).contains(testname).parent().find('#edit').click({force:true});
    cy.get('[data-cy=edit-form]').should('be.visible');
    cy.get('[data-cy=edit-form]').find('#title').should('have.value', testname);
    cy.get('[data-cy=edit-form]').find('#description').should('have.value', 'Description');
    cy.wait(200);
    cy.get('[data-cy=edit-form] > #title').click().clear().type(testNewname).should('have.value', testNewname);
    cy.wait(200);
    cy.get('#submit').click();
    cy.wait(1000);
    cy.visit('/browse');
    cy.get('.caff-title', { timeout: 15000 }).should('contain', testNewname);
  });

  it('delete caff', () => {
    cy.get('.caff-title', { timeout: 15000 }).contains(testNewname).parent().find('#delete').click({force:true});
    cy.get('[data-cy=confirm-buttons]').should('be.visible');
    cy.get('[data-cy=confirm-buttons]').find('#accept').should('be.visible').click();
    cy.get('.caff-title', { timeout: 15000 }).should('not.contain', testNewname);
  });

  it('buy caff', () => {
    cy.get('[data-cy=add-button]', { timeout: 5000 }).click();
    cy.get('[data-cy=add-form]').should('be.visible');
    cy.wait(200);
    cy.get('[data-cy=add-form] > #title').click().type(testBuyname).should('have.value', testBuyname);
    cy.wait(200);
    cy.get('[data-cy=add-form] > #description').click().type('Description').should('have.value', 'Description');
    cy.wait(200);
    cy.get('#upload').selectFile('cypress/fixtures/2.caff', { force: true });
    cy.get('#submit').click();
    cy.location('pathname').should('contain', '/browse/');
    cy.visit('/browse');
    cy.get('.caff-title', { timeout: 15000 }).should('contain', testBuyname);
  
    cy.get('[data-cy=caff-list] > .caff', { timeout: 15000 }).should('have.length.at.least', 1);
    cy.get('.caff-title', { timeout: 15000 }).contains(testBuyname).click({ force: true });
    cy.location('pathname').should('contain', '/browse/');
    cy.get('#buy').click();
    cy.get('[data-cy=confirm-buttons]').should('be.visible');
    cy.get('[data-cy=confirm-buttons]').find('#accept').should('be.visible').click();
    cy.location('pathname').should('contain', '/inventory/');
    cy.get('#back').click();
    cy.get('.caff-title', { timeout: 15000 }).should('contain', testBuyname);
  });
});
